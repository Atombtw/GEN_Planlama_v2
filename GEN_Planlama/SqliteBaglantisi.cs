using System.Data.SQLite;

namespace GEN_Planlama
{
    class SqliteBaglantisi
    {
        public SQLiteConnection baglanti()
        {
            SQLiteConnection baglan = new SQLiteConnection("Data Source = Y:\\BILGI TEKNOJILERI PROGRAMLAR\\Database\\GEN_Planlama.db; Version=3;");
            baglan.Open();
            return baglan;
        }
    }
}
