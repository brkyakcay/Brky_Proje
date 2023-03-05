namespace StringApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sayilar = new int[] { 12, 89, 65, 89, 456 };
            var isimler = new List<string> { "berkay", "fatih", "mehmet", "Info" };

            isimler.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();
            sayilar.ToList().ForEach(x => Console.WriteLine(x));

            var isimStr = String.Join(", ", isimler);
            var sayiStr = String.Join("---", sayilar);


            Console.WriteLine(isimStr);
            Console.WriteLine(sayiStr);

        }
    }
}