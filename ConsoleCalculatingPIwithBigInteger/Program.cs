using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ConsoleCalculatingPiWithBigInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 150; Console.WindowHeight = 50;
            BigInteger a = 2, b = 0, c = 0, d = 2, x, y, adet = 1, r = 2, r2 = 4, pi = 3, u, w, m2, m, k = 1;
            Console.Write("Pi Sayısının virgülden sonra kaç basamağını hesaplamak istiyorsunuz?  ");
            int showingnumber = Int32.Parse(Console.ReadLine());
            int i = 0, decimalnumbers = (showingnumber + 2) * 2;
            while (i < decimalnumbers)
            {
                a *= 10;
                d *= 10;
                r *= 10;
                r2 *= 10;
                k *= 10;
                pi *= 10;
                i++;
            }
            Console.Write("Hesaplama adım adım veya sürekli döngü içinde yapılabilir.\n\t [A] Adım adım...\n\t [S] Sürekli...");
            var tus = Console.ReadKey().Key;
            if (tus == ConsoleKey.A)
            {
                while (true)
                {
                    m2 = ((a - c) * (a - c) + (b - d) * (b - d)) / k;
                    u = (a + c) / 2; w = (b + d) / 2;
                    x = r - (2 * r * (r - SquareRoot((u * u + w * w) / k, k))) / (2 * r);
                    y = SquareRoot(r2 - x * x / k, k);
                    m = SquareRoot(m2, k);
                    pi = m * adet;
                    Console.WriteLine(pi.ToString().Insert(1, ".").Substring(0, showingnumber + 2) + "\n\t adet: " + adet + "\n\t tek çizgi mesafesi: " +
                        m.ToString("".PadLeft(decimalnumbers + 1, '0')).Insert(1, ".") + "\n"); Console.ReadKey();
                    c = x; d = y;
                    adet *= 2;
                }
            }
            else if (tus == ConsoleKey.S)
            {
                Console.Clear();
                string str_pi = "", _str_pi = ""; int esitlik = 0; bool hesaplandi = false;
                while (!hesaplandi)
                {
                    m2 = ((a - c) * (a - c) + (b - d) * (b - d)) / k;
                    u = (a + c) / 2; w = (b + d) / 2;
                    x = r - (2 * r * (r - SquareRoot((u * u + w * w) / k, k))) / (2 * r);
                    y = SquareRoot(r2 - x * x / k, k);
                    m = SquareRoot(m2, k);
                    _str_pi = pi.ToString().Substring(0, showingnumber + 1);
                    pi = m * adet;
                    str_pi = pi.ToString().Substring(0, showingnumber + 1);
                    if (str_pi == _str_pi) esitlik++;
                    hesaplandi = esitlik > 2;
                    Console.CursorTop = 0; Console.CursorLeft = 0;
                    Console.Write(pi.ToString().Insert(1, ".").Substring(0, showingnumber + 2));
                    c = x; d = y;
                    adet *= 2;
                }
                Console.WriteLine("\n\nPi Sayısı hesaplandı");
                Console.ReadKey();
            }
        }

        private static BigInteger MesafeKare(BigInteger a, BigInteger b, BigInteger c, BigInteger d)
        {
            BigInteger m2 = (a - c) * (a - c) + (d - b) * (d - b);
            return m2;
        }

        private static BigInteger Mesafe(BigInteger a, BigInteger b, BigInteger c, BigInteger d)
        {
            BigInteger ret = 0;
            BigInteger m2 = (a - c) * (a - c) + (d - b) * (d - b);
            //ret = SquareRoot(m2);
            return ret;
        }

        private static BigInteger SquareRoot(BigInteger _bi, BigInteger kat) //Newton-Raphson Metodu
        {
            if (_bi == 0) return 0;
            BigInteger bi = _bi;
            BigInteger ret = 0, iterasyon = bi / 2; bool hs = true;
            BigInteger xn = iterasyon, fxn = xn * xn / kat - bi, _fxn, _xn; int i = 0;
            while (hs)
            {
                _fxn = fxn;
                if (xn == 0) break;
                _xn = ((xn * xn / kat + bi) * kat) / (2 * xn);
                xn = _xn;
                fxn = xn * xn / kat - bi;
                hs = fxn - _fxn > 10 || fxn - _fxn < -10;
                //hs = !((fxn - _fxn > 0 && fxn - _fxn < hassasiyet) || (_fxn - fxn > 0 && _fxn - fxn < hassasiyet));
                //hs = i < 20;
                i++;
            }
            ret = xn;
            return ret;
        }
    }
}
