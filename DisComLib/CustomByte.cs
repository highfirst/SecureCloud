using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisComLib
{
	public class CustomByte
	{
		public static byte[] divitable = new byte[300];

		public CustomByte()
		{
			init();
		}

		public static byte add(byte a, byte b)
		{
			return (byte)(a ^ b);
		}

		public static void swap(ref byte a, ref byte b)
		{
			byte temp;
			temp = a;
			a = b;
			b = temp;
			return;
		}

		public static byte multiply(byte a, byte b)
		{
			int rlt = 0;
			int high_bit;
			for (int i = 0; i < 8; i++)
			{
				if ((a & 1) != 0) rlt ^= b;
				high_bit = ((b & 128) != 0) ? 1 : 0;
				b = (byte)(b << 1);
				if (high_bit != 0) b = (byte)(b ^ 27);
				a >>= 1;
			}
			return (byte)(rlt & 255);
		}

		public static void init()
		{
			for (int i = 0; i < 256; i++)
			{
				for (int j = 0; j < 256; j++)
				{
					if (multiply((byte)i, (byte)j) == 1) divitable[i] = (byte)j;
				}
			}
		}

		public static byte divide(byte a, byte b)
		{
			return multiply(a, divitable[b]);
		}

		public static bool lupDecom(byte[,] a, byte[,] l_mat, byte[,] u, byte[] pi, int dimen)
		{
			int i, k, tk, j;
			byte p;
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
				pi[i] = (byte)i;
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
						u[i, j] = add(u[i, j], multiply(u[i, k], u[k, j]));
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

		public static bool lupSolve(byte[,] a, byte[] pi, byte[] b, byte[] x, int dimen, byte[,] l_mat, byte[,] u)
		{
			int i, j;
			byte[] y = new byte[300];
			y[0] = b[pi[0]];
			for (i = 1; i < dimen; i++)
			{
				y[i] = b[pi[i]];
				for (j = 0; j < i; j++) y[i] = add(y[i], multiply(l_mat[i, j], y[j]));
			}
			x[dimen - 1] = divide(y[dimen - 1], u[dimen - 1, dimen - 1]);
			for (i = dimen - 2; i >= 0; i--)
			{
				x[i] = y[i];
				for (j = i + 1; j < dimen; j++) x[i] = add(x[i], multiply(u[i, j], x[j]));
				x[i] = divide(x[i], u[i, i]);
			}
			return true;
		}

		public static bool inverseMatrix(byte[,] a, out byte[][] res, int dimen)
		{
			int i, j;
			res = new byte[dimen][];
			for (i = 0; i < dimen; i++) res[i] = new byte[dimen];
			byte[] pi = new byte[300], e = new byte[300];
			byte[,] l_mat = new byte[dimen, dimen];
			byte[,] u = new byte[dimen, dimen];
			l_mat[0, 0] = 0;
			if (!lupDecom(a, l_mat, u, pi, dimen)) return false;
			for (i = 0; i < dimen; i++)
			{
				for (j = 0; j < 300; j++) e[j] = 0;
				e[i] = 1;
				if (!lupSolve(a, pi, e, res[i], dimen, l_mat, u)) return false;
			}
			for (i = 0; i < dimen; i++)
				for (j = i + 1; j < dimen; j++)
					swap(ref res[i][j], ref res[j][i]);
			return true;
		}
	}
}
