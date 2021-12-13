using System;

class Test {
	static Random rand = new Random();
	static void Main(String[] args) {
		var tuple = GetRange(args[0], args[1]);
		if (tuple.low == -1 && tuple.high == -1) {
			return;
		}
		int l = tuple.low;
		int h = tuple.high;
		bool avg = true;
		int sum = 0, count = 0;
		int rounds = 1;
		while (avg) {
			//var rand = Get5Random(l, h, even, zero, sum, count);
			var rand = Get5Random(l, h, out int even, out int zero, ref sum, ref count);
			//Console.wirte("");
			double average = (double)sum/count ;
			double mid = (double)(l + h)/2;
			average = Math.Round(average, 5);
			//Console.WriteLine(average);

			//double x = 1493.1987;
			string s1 = average.ToString("#.00000");
			

			if (average < mid)
			{
				Console.WriteLine("{0}, {1}, {2}, {3}, {4}   ev:{5}  od:{6}  ze:{7}  accu_sum:{8}  accu_count:{9}  avg={10} < midpoint {11} ({12})", rand.r1, rand.r2, rand.r3, rand.r4, rand.r5, even, (5 - even - zero), zero, sum, count, s1, mid, rounds);
				rounds++;
			}
			else
			{
				
				Console.WriteLine("{0}, {1}, {2}, {3}, {4}   ev:{5}  od:{6}  ze:{7}  accu_sum:{8}  accu_count:{9}  avg={10} >= midpoint {11} ({12})", rand.r1, rand.r2, rand.r3, rand.r4, rand.r5, even, (5 - even - zero), zero, sum, count, s1, mid, rounds);
				rounds++;

				avg = false;
			}

		}
		
		
	}
	
	public static (int low, int high) GetRange(String s1, String s2) {
		
		if (Int32.TryParse(s1, out int f) && Int32.TryParse(s2, out int s) && f != s) {
			return (Math.Min(f, s), Math.Max(f, s));
		}else {
			return (-1, -1);
		}
	}
	
	public static void EvenOrZero (in int number, ref int e, ref int z) {
		if (number == 0) {
			z++;
		}
		if (number % 2 == 0 && number != 0) {
			e++;
		}
	}
	
	public static (int r1, int r2, int r3, int r4, int r5) Get5Random(in int begin, in int end, out int even, out int zero, ref int sum, ref int count) {
		
		even = 0;
		zero = 0;
		int[] randArray = new int[5];
		for (int i = 0; i < 5; i++) {
			int num = rand.Next(begin, end+1);
			randArray[i] = num;
			EvenOrZero(randArray[i],ref even,ref zero);
			sum += randArray[i];
			count += 1;
		}
		return (randArray[0], randArray[1], randArray[2], randArray[3], randArray[4]);
	} 
	
	
	
}