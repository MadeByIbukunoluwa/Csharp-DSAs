
// if the children property of the nodes didn't exist, we would be 
namespace VariantsOfTrees
{
    class Trees
    {
        static public void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();
            tree.Root = new TreeNode<int>()
            {
                Parent = null,
                Data = 56,
            };
            tree.Root.Children = new List<TreeNode<int>>()
            {
                new TreeNode<int>() { Data = 89},
                new TreeNode<int>() {Data = 59},
                new TreeNode<int>() { Data = 34}
            };
            tree.Root.Children[2].Children = new List<TreeNode<int>>()
            {
                new TreeNode<int>() { Data = 35 , Parent = tree.Root.Children[2]}
            };
            // Company Structure
            // we will create a tree that will represent the structure of a company
            Tree<Person> company = new Tree<Person>();

            company.Root = new TreeNode<Person>()
            {
                Data = new Person(1, "Ibukunoluwa Akintobi", "Chief Executive Officer")
            };
            company.Root.Children = new List<TreeNode<Person>>()
            {
                new TreeNode<Person>() {
                    Data = new Person(2,"John Smith", "Head of Development"),
                    Parent = company.Root
                },
                new TreeNode<Person>() {
                    Data = new Person(3, "Mary Fox", "Head of Research"),
                    Parent = company.Root
                },
                new TreeNode<Person>() {
                    Data = new Person(4,"Lily Smith","Head of Sales" ),
                    Parent = company.Root
                },
            };
            // 1st child 
            company.Root.Children[0].Children = new List<TreeNode<Person>>()
            {
                new TreeNode<Person>() {
                    Data = new Person(3, "Chris Morris", "Senior Developer"),
                    Parent = company.Root.Children[0]
                },
            };
            company.Root.Children[0].Children[0].Children = new List<TreeNode<Person>>()
            {
                new TreeNode<Person>() {
                    Data = new Person(3, "Eric Green", "Junior Developer") ,
                    Parent =  company.Root.Children[0].Children[0]
                },
                new TreeNode<Person>() {
                    Data = new Person(3, "Sodiq Akinjobi", "Junior Developer") ,
                    Parent = company.Root.Children[0].Children[0]
                },
            };

            company.Root.Children[0].Children[0].Children[1].Children = new List<TreeNode<Person>>()
            {
                new TreeNode<Person>() {
                    Data = new Person(3, "Olamide Abdul", "Developer Intern"),
                    Parent =  company.Root.Children[0].Children[0].Children[1]
               },
            };


            //2nd child 

            company.Root.Children[1].Children = new List<TreeNode<Person>>()
            {
                new TreeNode<Person>() {
                    Data = new Person(2,"Jimmy Stewart", "Senior Researcher"),
                    Parent =  company.Root.Children[1]
                },
                new TreeNode<Person>() {
                    Data = new Person(3, "Andy Wood", "Senior Researcher"),
                    Parent =  company.Root.Children[1]
                },
            };

            //3rd child
            company.Root.Children[2].Children = new List<TreeNode<Person>>()
            {
                new TreeNode<Person>() {
                    Data = new Person(2,"Anthony Black", "Senior Sales Specialist"),
                    Parent = company.Root.Children[2]
                },
                new TreeNode<Person>() {
                    Data = new Person(3, "Angela Evans", "Senior Sales Specialist"),
                    Parent = company.Root.Children[2]
               },
            };
            company.Root.Children[2].Children[0].Children = new List<TreeNode<Person>>()
            {
                new TreeNode<Person>() {
                    Data = new Person(2,"Paula Scott", "Junior Sales Specialist"),
                    Parent = company.Root.Children[2].Children[0]
               },
                new TreeNode<Person>() {
                    Data = new Person(3, "Sarah Wattpad", "Junior Sales Specialist"),
                    Parent = company.Root.Children[2].Children[0]
               },
            };
            int heightOfPaula = company.Root.Children[2].Children[0].Children[0].GetHeight();
            Console.WriteLine(heightOfPaula.ToString());
        }
    }
}