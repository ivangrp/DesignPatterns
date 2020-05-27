namespace DessingPatterns
{
    using System;
    using System.Diagnostics;

    class Program
    {
        static void Main(string[] args)
        {
            //SingleResponsibilityMethod();
            //OpenClosedPrincipleMethod();
            LiskovSubstitutionPrincipleMethod();

            Console.ReadKey();
        }

        #region SingleResponsibility
        public static void SingleResponsibilityMethod()
        {
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I ate a bug");
            Console.WriteLine(j);

            var persistence = new Persistence();
            var fileName = @"C:\Users\ivang\Downloads\journal.txt";
            persistence.SaveToFile(j, fileName, true);
            Process.Start(fileName);
        }
        #endregion

        #region OpenClosedPrinciple
        public static void OpenClosedPrincipleMethod()
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = { apple, tree, house };

            var pf = new ProductFilter();
            Console.WriteLine("Green products (old):");
            foreach (var p in pf.FilterByColor(products, Color.Green))
                Console.WriteLine($" - {p.Name} is green");

            var bf = new BetterFilter();
            Console.WriteLine("Green products (new):");
            foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
                Console.WriteLine($" - {p.Name} is green");

            Console.WriteLine("Large products");
            foreach (var p in bf.Filter(products, new SizeSpecification(Size.Large)))
                Console.WriteLine($" - {p.Name} is large");

            Console.WriteLine("Large blue items");
            foreach (var p in bf.Filter(products,
                new AndSpecification<Product>(new ColorSpecification(Color.Blue), new SizeSpecification(Size.Large)))
            )
            {
                Console.WriteLine($" - {p.Name} is big and blue");
            }
        }
        #endregion

        #region LiskovSubstitutionPrinciple
        static public int Area(Rectangle r) => r.Width * r.Height;

        /// <summary>
        /// El principio de sustitucion de liskov dice que se debe poder clasificar el elenco a un tipo base
        /// y que la operacion deberia ser generalmente correcta
        /// </summary>
        public static void LiskovSubstitutionPrincipleMethod()
        {
            Rectangle rc = new Rectangle(2, 3);
            Console.WriteLine($"{rc} has area {Area(rc)}");

            Square sq = new Square();
            sq.Width = 4;
            Console.WriteLine($"{sq} has area {Area(sq)}");
        }
        #endregion
    }
}
