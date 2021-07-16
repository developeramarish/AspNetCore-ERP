namespace FinalProject.Erp.Common.Tools
{
    public static class TextFunc
    {
        public static string TextControl(string Metin)
        {
            if (string.IsNullOrWhiteSpace(Metin))
                Metin = "";

            string deger = Metin.Trim();

            deger = deger.Replace("'", "");
            deger = deger.Replace("<", "");
            deger = deger.Replace(">", "");
            deger = deger.Replace("&", "");
            deger = deger.Replace("[", "");
            deger = deger.Replace("]", "");
            deger = deger.Trim();
            if (deger == null)
            {
                deger = "";
            }

            deger = TurkceKarakter(deger);

            return deger;
        }

        private static string TurkceKarakter(string veri)
        {
            if (veri == null) veri = "";

            veri = veri.Replace("i", "İ");
            veri = veri.Replace("ş", "Ş");
            veri = veri.Replace("ç", "Ç");
            veri = veri.Replace("ğ", "Ğ");
            veri = veri.Replace("ü", "Ü");
            veri = veri.Replace("ö", "Ö");
            veri = veri.Replace("ı", "I");

            veri = veri.ToUpper();

            return veri;
        }
    }
}