using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Security.Cryptography;
using System.IO;

namespace DisComLib
{
	class SecretSharing
	{
		int n, k;
		int[] offsets;
		string[] outFiles, inFiles;
		byte[] input;
		BigInteger secret;
		BigInteger[] coeff;
		BigInteger mod = BigInteger.Parse("2165932209443298812718061332381661913045046342486808611050860488803697026892430324056380189268936018710183690963783574209");

		public int[] Offsets
		{
			get { return offsets; }
			set { offsets = value; }
		}

		public int N
		{
			get { return n; }
			set { n = value; }
		}
		public int K
		{
			get { return k; }
			set { k = value; }
		}
		public string[] OutFiles
		{
			get { return outFiles; }
			set { outFiles = value; }
		}

		public string[] InFiles
		{
			get { return inFiles; }
			set { inFiles = value; }
		}

		public byte[] Input
		{
			get { return input; }
			set { input = value; }
		}
		public SecretSharing(int n, int k)
		{
			this.n = n;
			this.k = k;
			outFiles = new string[n];
			inFiles = new string[k];
			coeff = new BigInteger[k];
			offsets = new int[k];
			for (int i = 0; i < k; i++) offsets[i] = 0;
		}

		public static void AppendString(string path, string text)
		{
			using (StreamWriter sw = File.AppendText(path))
			{
				sw.Write(text);
			}
		}

		public byte[] Join()
		{
			BigInteger[,] a = new BigInteger[k, k];
			BigInteger[] b = new BigInteger[k], x = new BigInteger[k];
			readAB(a, b);
			if (!solveInt(a, b, x, k))
			{
				throw new Exception("Cannot solve the equation(secretsharing)1");
			}
			return x[0].ToByteArray();
		}

		private void readAB(BigInteger[,] a, BigInteger[] b)
		{
			byte[] numBuffer, xBuffer, yBuffer;
			BigInteger x;
			int i, j, numByte;

			for (i = 0; i < k; i++)
			{
				ReadBytes(inFiles[i], 2, offsets[i], out numBuffer);
				offsets[i] = 2;
				numByte = (int)(numBuffer[0] << 8) + (int)(numBuffer[1]);
				xBuffer = new byte[numByte];
				ReadBytes(inFiles[i], numByte, offsets[i], out xBuffer);
				offsets[i] += numByte;
				a[i, 0] = 1;
				a[i, 1] = new BigInteger(xBuffer);
				x = a[i, 1];
				for (j = 2; j < k; j++)
				{
					a[i, j] = multiply(x, a[i, 1]);
					x = a[i, j];
				}
				ReadBytes(inFiles[i], 2, offsets[i], out numBuffer);
				offsets[i] += 2;
				numByte = (int)(numBuffer[0] << 8) + (int)(numBuffer[1]);
				yBuffer = new byte[numByte];
				ReadBytes(inFiles[i], numByte, offsets[i], out yBuffer);
				offsets[i] += numByte;
				b[i] = new BigInteger(yBuffer);
			}
			return;

		}

		private void swap(ref int a, ref int b)
		{
			int temp;
			temp = a;
			a = b;
			b = temp;
		}

		private void swap(ref BigInteger a, ref BigInteger b)
		{
			BigInteger temp;
			temp = a;
			a = b;
			b = temp;
		}

		private BigInteger ModInverse(BigInteger g, BigInteger p)
		{
			BigInteger a = new BigInteger();
			BigInteger b = new BigInteger();
			BigInteger c = new BigInteger();
			GCD(out a, out b, g, p, out c);
			if (a < 0)
			{
				a += p;
			}
			return a;
		}

		private void GCD(out BigInteger x, out BigInteger y, BigInteger a, BigInteger b, out BigInteger gcd)
		{
			if (a < 0 || b < 0)
			{
				gcd = 0;
				y = 0;
				x = 0;
				return;
			}

			BigInteger A = a, B = b, X = 0, Y = 1;
			BigInteger lastX = 1, lastY = 0;

			BigInteger q, temp, r;
			while (B != 0)
			{
				q = BigInteger.DivRem(A, B, out r);

				A = B;
				B = r;

				temp = X;
				X *= q;
				X = lastX - X;
				lastX = temp;

				temp = Y;
				Y *= q;
				Y = lastY - Y;
				lastY = temp;
			}

			x = lastX;

			y = lastY;

			gcd = A;

		}

		private BigInteger divide(BigInteger a, BigInteger b)
		{
			BigInteger c = new BigInteger();
			c = ModInverse(b, mod);
			return multiply(a, c);
		}

		private BigInteger add(BigInteger a, BigInteger b)
		{
			BigInteger c = (a + b) % mod;
			if (c < 0) return c + mod;
			else return c;
		}

		private BigInteger multiply(BigInteger a, BigInteger b)
		{
			BigInteger c = (a * b) % mod;
			if (c < 0) return c + mod;
			else return c;
		}

		private BigInteger sub(BigInteger a, BigInteger b)
		{
			BigInteger c = (a - b) % mod;
			if (c < 0) return c + mod;
			else return c;
		}

		bool lupDecom(BigInteger[,] a, BigInteger[,] l_mat, BigInteger[,] u, int[] pi, int dimen)
		{
			int i, k, tk, j;
			BigInteger p;
			for (i = 0; i < dimen; i++)
			{
				for (j = 0; j < dimen; j++)
				{
					u[i, j] = a[i, j];
					l_mat[i, j] = 0;
				}
				l_mat[i, i] = 1;
			}
			for (i = 0; i < dimen; i++)
			{
				pi[i] = i;
			}
			for (k = 0; k < dimen; k++)
			{
				p = 0; tk = k;
				for (i = k; i < dimen; i++)
				{
					if (p < u[i, k]) p = u[i, k];
					tk = i;
				}
				if (p == 0) return false;
				if (tk != k)
				{
					swap(ref pi[k], ref pi[tk]);
					for (i = 0; i < dimen; i++)
					{
						swap(ref u[k, i], ref u[tk, i]);
					}
				}
				for (i = k + 1; i < dimen; i++)
				{
					u[i, k] = divide(u[i, k], u[k, k]);
					for (j = k + 1; j < dimen; j++)
					{
						u[i, j] = sub(u[i, j], multiply(u[i, k], u[k, j]));
					}
				}
			}
			for (i = 0; i < dimen; i++)
			{
				for (j = 0; j < i; j++)
				{
					l_mat[i, j] = u[i, j];
					u[i, j] = 0;
				}
			}
			return true;
		}

		bool lupSolve(BigInteger[,] a, int[] pi, BigInteger[] b, BigInteger[] x, int dimen, BigInteger[,] l_mat, BigInteger[,] u)
		{
			int i, j;
			BigInteger[] y = new BigInteger[300];
			y[0] = b[pi[0]];
			for (i = 1; i < dimen; i++)
			{
				y[i] = b[pi[i]];
				for (j = 0; j < i; j++) y[i] = sub(y[i], multiply(l_mat[i, j], y[j]));
			}
			x[dimen - 1] = divide(y[dimen - 1], u[dimen - 1, dimen - 1]);
			for (i = dimen - 2; i >= 0; i--)
			{
				x[i] = y[i];
				for (j = i + 1; j < dimen; j++) x[i] = sub(x[i], multiply(u[i, j], x[j]));
				x[i] = divide(x[i], u[i, i]);
			}
			return true;
		}

		bool solveInt(BigInteger[,] a, BigInteger[] b, BigInteger[] x, int dimen)
		{
			BigInteger[,] l_mat = new BigInteger[dimen, dimen], u = new BigInteger[dimen, dimen];
			int[] pi = new int[dimen];
			if (!lupDecom(a, l_mat, u, pi, dimen))
			{
				return false;
			}
			if (!lupSolve(a, pi, b, x, dimen, l_mat, u))
			{
				return false;
			}
			return true;
		}

		public BigInteger randomBigInteger(RNGCryptoServiceProvider rng, BigInteger bound)
		{
			var buffer = bound.ToByteArray();
			var n = buffer.Length;
			var msb = buffer[n - 1];
			var mask = 0;
			while (mask < msb)
				mask = (mask << 1) + 1;
			while (true)
			{
				rng.GetBytes(buffer);
				buffer[n - 1] &= (byte)mask;
				var r = new BigInteger(buffer);
				if (r < secret)
					return r;
			}

		}

		public bool Split()
		{
			if (input == null) return false;
			secret = new BigInteger(input);
			int i;
			RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
			for (i = 0; i < k - 1; i++)
			{
				coeff[i] = randomBigInteger(rng, secret);
			}
			BigInteger share, tx;
			BigInteger[] xes = new BigInteger[n];
			byte[] wrBuf = new byte[10], ybuffer = new byte[200], xbuffer = new byte[200];
			int numByte, j, flag;
			for (i = 0; i < n; i++)
			{
				share = secret;
				flag = 1;
				while (flag != 0)
				{
					flag = 0;
					xes[i] = randomBigInteger(rng, secret);
					for (j = 0; j < i; j++)
					{
						if (xes[i] == xes[j])
						{
							flag = 1;
							break;
						}
					}
				}
				xbuffer = xes[i].ToByteArray();
				numByte = xbuffer.Length;
				wrBuf[0] = (byte)(numByte >> 8);
				wrBuf[1] = (byte)(numByte & 255);
				AppendBytes(outFiles[i], wrBuf, 2);
				AppendBytes(outFiles[i], xbuffer, numByte);
				tx = xes[i];
				for (j = 0; j < k - 1; j++)
				{
					share = (share + tx * coeff[j]) % mod;
					tx = (tx * xes[i]) % mod;
				}
				ybuffer = share.ToByteArray();
				numByte = ybuffer.Length;
				wrBuf[0] = (byte)(numByte >> 8);
				wrBuf[1] = (byte)(numByte & 255);
				AppendBytes(outFiles[i], wrBuf, 2);
				AppendBytes(outFiles[i], ybuffer, numByte);
			}
			return true;
		}

		public static void AppendBytes(string path, byte[] bytes, int numByte)
		{
			//argument-checking here.

			using (var stream = new FileStream(path, FileMode.Append))
			{
				stream.Write(bytes, 0, numByte);
			}
		}

		public static void ReadBytes(string path, int numByte, int offset, out byte[] buffer)
		{
			buffer = new byte[numByte];
			using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				stream.Seek(offset, SeekOrigin.Begin);
				stream.Read(buffer, 0, numByte);
			}
		}
	}
}
