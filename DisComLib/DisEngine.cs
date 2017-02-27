using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace DisComLib
{
	public class DisEngine
	{
		int countClouds;
		int threshold;
		int max_size = 1000000;
		string inFileName;
		string[] outFileNames;
		byte[] a, fileBuffer;
		string dis = "e:\\test\\dis.txt";

		public void encrypt_stream(string inFileName, int countClouds, int threshold)
		{
			byte[] cipherBytes;
			byte[] key_iv;
			int once_quan;

			this.countClouds = countClouds;
			this.threshold = threshold;
			this.inFileName = inFileName;
			a = new byte[countClouds * threshold];
			SecretSharing ss = new SecretSharing(countClouds, threshold);
			openOutputFiles();
			ss.OutFiles = outFileNames;
			CustomByte.init();

			using (RijndaelManaged objRM = new RijndaelManaged())
			{
				objRM.GenerateKey();
				objRM.GenerateIV();

				key_iv = new byte[objRM.Key.Length + objRM.IV.Length + 1];
				System.Buffer.BlockCopy(objRM.Key, 0, key_iv, 0, objRM.Key.Length);
				System.Buffer.BlockCopy(objRM.IV, 0, key_iv, objRM.Key.Length, objRM.IV.Length);
				key_iv[key_iv.Length - 1] = 0;
				ss.Input = key_iv;
				ss.Split();

				makeAMat();
				writeAMat();

				ICryptoTransform encryptor = objRM.CreateEncryptor();

				int blockSize = objRM.BlockSize * threshold / 8;
				once_quan = (max_size / blockSize) * blockSize - 1;

				using (FileStream fs = new FileStream(inFileName, FileMode.Open, FileAccess.Read))
				{
					using (BinaryReader br = new BinaryReader(fs, new ASCIIEncoding()))
					{
						while (true)
						{
							fileBuffer = br.ReadBytes(once_quan);
							if (fileBuffer.Length == 0) break;
							SecretSharing.AppendString(dis, fileBuffer.Length.ToString() + "\n");
							using (MemoryStream objMS = new MemoryStream())
							{
								using (CryptoStream objCS = new CryptoStream(objMS, encryptor, CryptoStreamMode.Write))
								{
									objCS.Write(fileBuffer, 0, fileBuffer.Length);
									objCS.FlushFinalBlock();
									cipherBytes = objMS.ToArray();
								}
							}
							SecretSharing.AppendString(dis, cipherBytes.Length.ToString() + "\n");

							byte[] b = new byte[((cipherBytes.Length + threshold - 1) / threshold) * threshold];
							int leftBytes = cipherBytes.Length % threshold;
							int column = b.Length / threshold;

							int i, j, endCol = (leftBytes == 0) ? column : column - 1;

							for (i = b.Length - 1; i >= b.Length - 1 - threshold; i--) b[i] = 0;
							for (i = 0; i < endCol; i++)
							{
								for (j = 0; j < threshold; j++)
								{
									b[j * column + i] = cipherBytes[threshold * i + j];
								}
							}
							for (i = 0; i < leftBytes; i++) b[i * column + column - 1] = cipherBytes[threshold * (column - 1) + i];

							byte[] c = MatMul(a, b, countClouds, threshold, column);

							for (i = 0; i < countClouds; i++)
							{
								var sub = c.Skip(i * column).Take(column).ToArray();
								SecretSharing.AppendBytes(outFileNames[i], sub, column);
							}
						}
					}
				}
			}

		}

		public static byte[] MatMul(byte[] a, byte[] b, int n, int m, int k)
		{
			byte[] c = new byte[n * k];
			byte temp;
			int i, j, l;
			for (i = 0; i < n; i++)
			{
				for (j = 0; j < k; j++)
				{
					temp = 0;
					for (l = 0; l < m; l++)
					{
						temp = CustomByte.add(temp, CustomByte.multiply(a[i * m + l], b[l * k + j]));
					}
					c[i * k + j] = temp;
				}
			}
			return c;
		}

		private void writeAMat()
		{
			byte[] buffer = new byte[threshold];
			int i, j;
			for (i = 0; i < countClouds; i++)
			{
				for (j = 0; j < threshold; j++) buffer[j] = a[i * threshold + j];
				SecretSharing.AppendBytes(outFileNames[i], buffer, buffer.Length);
			}
		}

		private void makeAMat()
		{
			RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
			byte[] buffer = new byte[10];
			int i, j;
			byte rand_byte;
			for (i = 0; i < countClouds; i++)
			{
				int row_num = i * threshold;
				while (true)
				{
					rng.GetNonZeroBytes(buffer);
					rand_byte = buffer[0];
					for (j = 0; j < i; j++)
					{
						if (rand_byte == a[j * threshold + 1]) break;
					}
					if (j < i) continue;
					else break;
				}
				a[row_num] = 1;
				for (j = row_num + 1; j < row_num + threshold; j++)
				{
					a[j] = CustomByte.multiply(a[j - 1], rand_byte);
				}
			}
			return;
		}

		private void openOutputFiles()
		{
			int i;
			outFileNames = new string[countClouds];
			for (i = 0; i < countClouds; i++)
			{
				StringBuilder sb = new StringBuilder(inFileName);
				outFileNames[i] = sb.Append(i + 1).ToString();
				using (FileStream fs = new FileStream(outFileNames[i], FileMode.Create)) { }
			}
		}
	}
}
