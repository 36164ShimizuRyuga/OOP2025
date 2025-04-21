namespace ProductSample {
    internal class Program {
        static void Main(string[] args) {

            Product karinto = new Product(123, "かりんとう", 180);
            Product daihuku = new Product(124, "だいふく", 190);


            //税抜き価格を表示 
            Console.WriteLine(karinto.Name + "の税抜き価格は" + karinto.Price + "円です");

            Console.WriteLine(daihuku.Name + "の税抜き価格は" + daihuku.Price + "円です");
            //消費税額の表示

            Console.WriteLine(karinto.Name + "の消費税額は" + karinto.GetTax() + "です");

            Console.WriteLine(daihuku.Name + "の消費税額は" + daihuku.GetTax() + "です");

            //税込み価格を表示
            Console.WriteLine(karinto.Name + "の税込み価格は" + karinto.GetPraiceIneludingTex() + "です");

            Console.WriteLine(daihuku.Name + "の税込み価格は" + daihuku.GetPraiceIneludingTex() + "です");
        }
    }
}