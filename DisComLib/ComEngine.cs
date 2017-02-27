using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace DisComLib
{
	public class ComEngine
	{
		int countClouds, threshold, max_size = 10000000;
		int[] offsets;
		string[] inFiles;
		string outFileName;
		byte[] a;
		string com = @"e:\test\com.txt";

		private void makeAMat()
		{
			int i, j;
			byte[] buffer;
			for (i = 0; i < threshold; i++)
			{
				SecretSharing.ReadBytes(inFiles[i], threshold, offsets[i], out buffer);
				offsets[i] += threshold;
				for (j = 0; j < threshold; j++) a[i * threshold + j] = buffer[j];
			}
			return;
		}

		private void inverseAMat()
		{
			int i, j;
			byte[,] aa = new byte[threshold, threshold];
			byte[][] result = new byte[threshold][];
			for (i = 0; i < threshold; i++) result[i] = new byte[threshold];
			for (i = 0; i < threshold; i++)
			{
				for (j = 0; j < threshold; j++)
				{
					aa[i, j] = a[i * threshold + j];
				}
			}
			CustomByte.inverseMatrix(aa, out result, threshold);
			for (i = 0; i < threshold; i++)
			{
				for (j = 0; j < threshold; j++) a[i * threshold + j] = result[i][j];
			}
		}

		public bool decrypt_stream(int countClouds, int threshold, string[] inFiles, string outFileName)
		{
			int i, j;

			this.countClouds = countClouds;
			this.threshold = threshold;
			this.inFiles = inFiles;
			this.outFileName = outFileName;

			using (FileStream fs = new FileStream(outFileName, FileMode.Create)) { }
			a = new byte[threshold * threshold];
			offsets = new int[threshold];
			CustomByte.init();

			SecretSharing ss = new SecretSharing(countClouds, threshold);
			ss.InFiles = inFiles;
			byte[] key_iv = ss.Join();
			offsets = ss.Offsets;

			var key = key_iv.Take(32).ToArray();
			var iv = key_iv.Skip(32).Take(16).ToArray();

			makeAMat();
			inverseAMat();

			FileInfo fi = new FileInfo(inFiles[0]);
			long bytesLeft = fi.Length - offsets[0];
			int once_col;

			using (RijndaelManaged objRM = new RijndaelManaged())
			{
				int blockSize = objRM.BlockSize / 8;
				ICryptoTransform decryptor = objRM.CreateDecryptor(key, iv);
				once_col = (max_size / (blockSize * threshold)) * blockSize;
				SecretSharing.AppendString(com, once_col.ToString() + "\n");
				long bytesRead = 0;
				while (bytesRead < bytesLeft)
				{

					if (bytesLeft - bytesRead < once_col) once_col = (int)(bytesLeft - bytesRead);
					byte[] buffer, c = new byte[threshold * once_col], b;

					for (i = 0; i < threshold; i++)
					{
						SecretSharing.ReadBytes(inFiles[i], once_col, offsets[i], out buffer);
						offsets[i] += once_col;
						for (j = 0; j < once_col; j++) c[i * once_col + j] = buffer[j];
					}

					bytesRead += once_col;

					b = DisEngine.MatMul(a, c, threshold, threshold, once_col);

					byte[] cipherBytes = new byte[b.Length];
					for (i = 0; i < once_col; i++)
					{
						for (j = 0; j < threshold; j++)
						{
							cipherBytes[threshold * i + j] = b[j * once_col + i];
						}
					}
					byte[] fileBuffer;
					SecretSharing.AppendString(com, cipherBytes.Length.ToString() + "\n");
					using (MemoryStream objMS = new MemoryStream())
					{
						using (CryptoStream objCS = new CryptoStream(objMS, decryptor, CryptoStreamMode.Write))
						{
							objCS.Write(cipherBytes, 0, (cipherBytes.Length / blockSize) * blockSize);
							objCS.FlushFinalBlock();
							fileBuffer = objMS.ToArray();
						}
					}
					SecretSharing.AppendString(com, fileBuffer.Length.ToString());

					SecretSharing.AppendBytes(outFileName, fileBuffer, fileBuffer.Length);
				}
			}
			return true;
		}
	}
}
