

using System;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Priority_Queue;

namespace StacksAndQueues
{
    class Program
    {
        private const int DISCS_COUNT = 10;
        private const int DELAY_MS = 250;
        private static int _columnSize = 30;

         static void Main(string[] args)
        {
            //Reversing strings
            //Stack<char> chars = new Stack<char>();
            //foreach (char c in "LETS REVERSE")
            //{
            //    chars.Push(c);
            //}
            //while (chars.Count > 0)
            //{
            //    Console.WriteLine(chars.Pop());
            //}
            //Console.WriteLine();

            //Tower of Hanoi
            //_columnSize = Math.Max(6, GetDiscsWidth(DISCS_COUNT));
            //HanoiTower algorithm = new HanoiTower(DISCS_COUNT);
            //algorithm.MoveCompleted += Algorithm_Visualize;
            //Algorithm_Visualize(algorithm, EventArgs.Empty);
            //algorithm.Start();

            //Random random = new Random();

            //CallCenter center = new CallCenter();

            //center.Call(1234);
            //center.Call(5678);
            //center.Call(1468);
            //center.Call(9641);

            //Console.WriteLine(center.Calls.Count);

            //while (center.AreWaitingCalls())

            //{
            //    IncomingCall call = center.Answer("Marcin");

            //    Log($"Call #{call.Id} from {call.ClientId} " +
            //        $"is answered by {call.Consultant}.");

            //    Thread.Sleep(random.Next(1000, 10000));

            //    center.End(call);

            //    Log($"Call #{call.Id} from {call.ClientId} " +
            //        $"is ended by {call.Consultant}."); 
            //}

            //CallCenterConcurrent center1 = new CallCenterConcurrent();

            //Parallel.Invoke(
            //    () => CallersAction(center1),
            //    () => ConsultantAction(center1, "Ibukunoluwa", ConsoleColor.Red),
            //    () => ConsultantAction(center1, "Temidayo", ConsoleColor.Yellow),
            //    () => ConsultantAction(center1, "BinLaden" ,ConsoleColor.Green)
            //);
            //As you can see, the calls are served in the correct order.
            //This means that the calls from clients with priority support
            //are served earlier than calls from clients with the standard
            //support plan, despite the fact that such calls need to wait
            //much longer to be answered.
            Random random = new Random();

            CallCenterPriority center = new CallCenterPriority();

            center.Call(1234);
            center.Call(5678);
            center.Call(1468);
            center.Call(9641, true);

            while(center.AreWaitingCalls())
            {
                IncomingCallP call = center.Answer("Marcio");
                Log($"Call #{call.Id} from {call.ClientId} is answered by {call.Consultant} / Mode: {(call.IsPriority ? "priority" : "normal")}");
                Thread.Sleep(random.Next(1000, 10000));
                center.End(call);
                Log($"Call #{call.Id} from {call.ClientId} is ended by {call.Consultant} / Mode: {(call.IsPriority ? "priority" : "normal")}");
            }

        }
        private static void Algorithm_Visualize(object sender, EventArgs e)
        {
            Console.Clear();

            HanoiTower algorithm = (HanoiTower)sender;

            if (algorithm.DiscsCount <= 0)
            {
                return;
            }

            char[][] visualization = InitializeVisualization(algorithm);
            PrepareColumn(visualization, 1, algorithm.DiscsCount,
                algorithm.From);
            PrepareColumn(visualization, 2, algorithm.DiscsCount,
                algorithm.To);
            PrepareColumn(visualization, 3, algorithm.DiscsCount,
                algorithm.Auxiliary);
            Console.WriteLine(Center("FROM") + Center("TO") +
                Center("AUXILIARY"));
            DrawVisualization(visualization);
            Console.WriteLine();
            Console.WriteLine($"Number of moves: {algorithm.MovesCount}");
            Console.WriteLine($"Number of discs: {algorithm.DiscsCount}");
            Thread.Sleep(DELAY_MS);

        }
        private static char[][] InitializeVisualization(HanoiTower algorithm)
        {
            char[][] visualization = new char[algorithm.DiscsCount][];

            for (int y = 0; y < visualization.Length; y++)
            {
                visualization[y] = new char[_columnSize * 3];
                for (int x = 0; x < _columnSize * 3; x++)
                {
                    visualization[y][x] = ' ';
                }
            }
            return visualization;
        }

        private static void PrepareColumn(char[][] visualization, int column, int discsCount, Stack<int> stack)
        {
            int margin = _columnSize * (column - 1);

            for (int y = 0; y < stack.Count; y++)
            {
                int size = stack.ElementAt(y);
                int row = discsCount - (stack.Count - y);
                int columnStart = margin + discsCount - size;
                int columnEnd = columnStart + GetDiscsWidth(size);

                for (int x = columnStart; x <= columnEnd; x++)
                {
                    visualization[row][x] = '=';
                }
            }
        }
        private static void DrawVisualization(char[][] visualization)
        {
            for (int y = 0; y < visualization.Length; y++)
            {
                Console.WriteLine(visualization[y]);
            }
        }

        private static string Center(string text)
        {
            int margin = (_columnSize - text.Length) / 2;
            return text.PadLeft(margin + text.Length).PadRight(_columnSize);
        }
        private static int GetDiscsWidth(int size)
        {
            return 2 * size - 1;
        }

        // Call center with a single consultant

        public class CallCenter
        {
            private int _counter = 0;

            public Queue<IncomingCall> Calls { get; private set; }

            public CallCenter()
            {
                Calls = new Queue<IncomingCall>();
            }

            public int Call(int clientId)
            {
                IncomingCall call = new IncomingCall()
                {
                    Id = ++_counter,
                    ClientId = clientId,
                    CallTime = DateTime.Now
                };
                Calls.Enqueue(call);
                return Calls.Count;
            }

            public IncomingCall Answer(string consultant)
            {
                if (Calls.Count > 0)
                {
                   IncomingCall Call = Calls.Dequeue();
                    Call.Consultant = consultant;
                    Call.StartTime = DateTime.Now;
                    return Call;
                }
                return null;
            }

            public void End(IncomingCall call)
            {
                call.EndTime = DateTime.Now;
            }
            public bool AreWaitingCalls ()
            {
                return Calls.Count > 0;
            }
           
        }
        private static void Log(string text)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] {text}");
        }

        //Call Center with multiple Consultants
        public class CallCenterConcurrent
        {
            private int _counter = 0;
            public ConcurrentQueue<IncomingCall> Calls { get; private set; }

            public CallCenterConcurrent()
            {
                Calls = new ConcurrentQueue<IncomingCall>();
            }
            public IncomingCall AnswerConcurrent(string consultant)
            {
                if (Calls.Count > 0 && Calls.TryDequeue(out IncomingCall call))
                {
                    call.Consultant = consultant;
                    call.StartTime = DateTime.Now;
                    return call;
                }
                return null;
            }
            public int Call(int clientId)
            {
                IncomingCall call = new IncomingCall()
                {
                    Id = ++_counter,
                    ClientId = clientId,
                    CallTime = DateTime.Now
                };
                Calls.Enqueue(call);
                return Calls.Count;
            }
            public void End(IncomingCall call)
            {
                call.EndTime = DateTime.Now;
            }
            public bool AreWaitingCalls()
            {
                return Calls.Count > 0;
            }
            private static void Log(string text)
            {
                Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] {text}");
            }
        }
        //CallersAction and ConsultantAction
        private static void CallersAction(CallCenterConcurrent center)
        {
            Random random = new Random();
            while(true)
            {
                int clientId = random.Next(1,9999);

                int waitingCount = center.Call(clientId);

                Log($"Incoming call from {clientId} waiting in the queue: {waitingCount}");

                Thread.Sleep(random.Next(1000,5000));
            }
        }

        private static void ConsultantAction(CallCenterConcurrent center, string name, ConsoleColor color)
        {
            Random random = new Random();
            while (true)
            {
                IncomingCall call = center.AnswerConcurrent(name);
                if (call != null)
                {
                    Console.ForegroundColor = color;
                    Log($"Call #{call.Id} from {call.ClientId} is answered by {call.Consultant}");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Thread.Sleep(random.Next(1000, 10000));
                    center.End(call);

                    Console.ForegroundColor = color;
                    Log($"Call #{call.Id} from {call.ClientId} is answered by {call.Consultant}");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Thread.Sleep(random.Next(500, 1000));
                }
                else
                {
                    Thread.Sleep(100);
                }

            }
        }
         //Call center with priority support
         public class CallCenterPriority
         {
            int _counter = 0;
            public SimplePriorityQueue<IncomingCallP> Calls { get; private set; }
            public CallCenterPriority()
            {
                Calls = new SimplePriorityQueue<IncomingCallP>();
            }
            public void Call(int clientId, bool isPriority = false)
            {
                IncomingCallP call = new IncomingCallP()
                {
                    Id = ++_counter,
                    ClientId = clientId,
                    CallTime = DateTime.Now,
                    IsPriority = isPriority
                };
                Calls.Enqueue(call, isPriority ? 0 : 1);
            }
            public IncomingCallP Answer(string consultant)
            {
                if (Calls.Count > 0)
                {
                    IncomingCallP call = Calls.Dequeue();
                    call.Consultant = consultant;
                    call.StartTime = DateTime.Now;
                    return call;
                }
                return null;
            }
            public void End(IncomingCallP call)
            {
                call.EndTime = DateTime.Now;
            }
            public bool AreWaitingCalls()
            {
                return Calls.Count > 0;
            }

        }

        }
}