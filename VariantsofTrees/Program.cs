
// if the children property of the nodes didn't exist, we would be

namespace VariantsOfTrees
{
    class Trees
    {
        private static char[][] InitializeVisualization(BinarySearchTree<int> tree, out int width)
        {
            int height = tree.GetHeight();
            width = (int)Math.Pow(2, height) - 1;
            char[][] console = new char[height * 2][];
            for (int i = 0; i < height * 2; i++)
            {
                console[i] = new char[COLUMN_WIDTH * width];
            }
            return console;
        }
        private static void DrawlineLeft(BinaryTreeNode<int> node, int row, int column, char[][] console, int columnDelta)
        {
            if (node.Left != null)
            {
                int startColumnIndex = COLUMN_WIDTH * (column - columnDelta) + 2;
                int endColumnIndex = COLUMN_WIDTH * column + 2;
                for (int x = startColumnIndex + 1; x < endColumnIndex; x++)
                {
                    console[row + 1][x] = '_';
                }
                console[row + 1][startColumnIndex] = '\u250c';
                console[row + 1][endColumnIndex] = '+';
            }
        }

        private static void DrawlineRight(BinaryTreeNode<int> node, int row, int column, char[][] console, int columnDelta)
        {
            if (node.Right != null)
            {
                int startColumnIndex = COLUMN_WIDTH * columnDelta + 2;
                int endColumnIndex = COLUMN_WIDTH * (column + columnDelta) + 1;
                for (int x = startColumnIndex + 1; x < endColumnIndex; x++)
                {
                    console[row + 1][x] = '_';
                }
                console[row + 1][startColumnIndex] = '+';
                console[row + 1][endColumnIndex] = '\u2510';
            }
        }

        private static void VisualizeNode(BinaryTreeNode<int> node, int row, int column, char[][] console, int width)
        {
            if (node != null)
            {
                char[] chars = node.Data.ToString().ToCharArray();
                int margin = (COLUMN_WIDTH - chars.Length) / 2;
                for (int i = 0; i < chars.Length; i++)
                {
                    console[row][COLUMN_WIDTH * column + i + margin] = chars[i];
                }
                int columnDelta = (width + 1) / (int)Math.Pow(2, node.GetHeight() + 1);
                VisualizeNode(node.Left, row + 2, column - columnDelta, console, width);
                VisualizeNode(node.Right, row + 2, column + columnDelta, console, width);
                DrawlineLeft(node, row, column, console, columnDelta);
                DrawlineRight(node, row, column, console, columnDelta);
            }
        }

        private static void VisualizeTree(BinarySearchTree<int> tree, string caption)
        {
            char[][] console = InitializeVisualization(tree, out int width);
            VisualizeNode(tree.Root, 0, width / 2, console, width);
            Console.WriteLine(caption);
            foreach (char[] row in console)
            {
                Console.WriteLine(row);
            }
        }
        private const int COLUMN_WIDTH = 5;

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
                Data = new Person(1, "Ibukunoluwa Akintobi", "Chief Executive Officer"),
                Parent = null
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
            Console.WriteLine(heightOfPaula.ToString()); // 4 which is correct 


            //Binary Trees
            //Simple Quiz
            BinaryTree<QuizItem> quiztree = GetTree();
            BinaryTreeNode<QuizItem> node = quiztree.Root;

            while (node != null)
            {
                if (node.Left != null || node.Right != null)
                {
                    Console.Write(node.Data.Text);
                    switch(Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.Y:
                            WriteAnswer(" Yes");
                            node = node.Left;
                            break;
                        case ConsoleKey.N:
                            WriteAnswer(" No");
                            node = node.Right;
                            break;
                    }
                }
                else
                {
                    WriteAnswer(node.Data.Text);
                    node = null;
                }
            }


            static BinaryTree<QuizItem> GetTree()
            {
                BinaryTree<QuizItem> tree = new BinaryTree<QuizItem>();
                tree.Root = new BinaryTreeNode<QuizItem>()
                {
                    Data = new QuizItem("Have you completed the university"),
                    Children = new List<TreeNode<QuizItem>>()
                    {
                        new BinaryTreeNode<QuizItem>()
                        {
                            Data = new QuizItem("Apply for a junior developer!")
                        },
                        new BinaryTreeNode<QuizItem>()
                        {
                            Data = new QuizItem("Will you find some time during the semester"),
                            Children = new List<TreeNode<QuizItem>>()
                            {
                                new BinaryTreeNode<QuizItem>()
                                {
                                    Data = new QuizItem("Apply for our long-time internship program!")
                                },
                                new BinaryTreeNode<QuizItem>()
                                {
                                    Data = new QuizItem("Apply for our summer internship program!")
                                },
                            }
                        },
                    }
                };
                tree.Count = 9;
                return tree;
            }
             static void WriteAnswer(string text)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(text);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            //Binary Search Trees
            

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            BinarySearchTree<int> binaryTree = new BinarySearchTree<int>();
            binaryTree.Root = new BinaryTreeNode<int>()
            {
                Data = 100,
                Parent = null
            };
            binaryTree.Root.Left = new BinaryTreeNode<int>()
            {
                Data = 50,
                Parent = binaryTree.Root
            };
            binaryTree.Root.Right = new BinaryTreeNode<int>()
            {
                Data = 150,
                Parent = binaryTree.Root
            };
            binaryTree.Count = 3;
            VisualizeTree(binaryTree, "The BST with three nodes(50,100,150)");


            binaryTree.Add(75);
            binaryTree.Add(125);
            VisualizeTree(binaryTree, "The BST after two nodes (75,125):");


            //binaryTree.Remove(25);
            //VisualizeTree(binaryTree, "The BST after removing the node 25");


            Console.Write("Pre-order traversal:\t");
            Console.Write(string.Join(",  ", binaryTree.Traverse(TraversalEnum.PREORDER).Select(n => n.Data)));

            Console.Write("\nIn-order traversal:\t");
            Console.Write(string.Join(",  ", binaryTree.Traverse(TraversalEnum.INORDER).Select(n => n.Data)));

            Console.Write("\nPost-order traversal:\t");
            Console.Write(string.Join(",  ", binaryTree.Traverse(TraversalEnum.POSTORDER).Select(n => n.Data)));

            Console.ReadLine();
        }
    }
}