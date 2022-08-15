using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ultities.Security.Hashing
{
    public class HashingHelper //Bizim için araç olduğu için çıplak kalabilir
    {

        public static void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)// verilen passwordu hash'ini oluşturur.Ayrıca salt'ını oluşturacak yapıyı içerir
        {
            using (var hmac= new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//Bir string'in byte karşılığını almak için yazılan kodlar
            }
        }


        public static bool VerifyPasswordHash(string password , byte[] passwordHash, byte[] passwordSalt)//sonradan sisteme girmek isteyenin verdiği passwordun veri kaynağımızdaki password ile eşleşip eşleşmediğine bakıyor
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }  
                return true;
             }
         }
    }
}
