namespace Algorithm;

public class DailyTemperatures
{
    /*
739. Daily Temperatures
Medium Topics:Staff,Array,Stack,Monotonic Stack,Weekly Contest 61
Hint

Given an array of integers temperatures represents the daily temperatures, 
return an array answer such that answer[i] is the number of days you have to wait after the i^th day to get a warmer temperature. 
If there is no future day for which this is possible, keep answer[i] == 0 instead.

 

Example 1:

Input: temperatures = [73,74,75,71,69,72,76,73]
Output: [1,1,4,2,1,1,0,0]
Example 2:

Input: temperatures = [30,40,50,60]
Output: [1,1,1,0]
Example 3:

Input: temperatures = [30,60,90]
Output: [1,1,0]
 

Constraints:

1 <= temperatures.length <= 10^5
30 <= temperatures[i] <= 100
     */
    // [73,74,75,71,69,72,76,73]
    // i=0, stack count=0, stack push 0
    // i=1, stack count=1, 74 > 73, prevIndex=0, pop stack 0, result[0]=1-0=1, stack push 1, stack count=1
    // i=2, stack count=1, 75 > 74, prevIndex=1, pop stack 1, result[1]=2-1=1, stack push 2, stack count=1
    // i=3, stack count=1, 71 < 75, stack push 3, stack count=2{2,3}
    // i=4, stack count=2, 69 < 71, stack push 4, stack count=3{2,3,4}
    // i=5, stack count=3, 72 > 69, prevIndex=4, pop stack 4, result[4]=5-4=1,
    //                     72 > 71, prevIndex=3, pop stack 3, result[3]=5-3=2,
    //                     72 > 75, stack push 5, stack count=2{2,5}
    // i=6, stack count=2, 76 > 72, prevIndex=5, pop stack 5, result[5]=6-5=1
    //                     76 > 75, prevIndex=2, pop stack 2, result[2]=6-2=4, stack push 6, stack count=1
    // i=7, stack count=1, 73 < 76, stack push 7, stack count=2{6,7}
    // result = [1,1,4,2,1,1,0,0]
    /*
解題說明
先想暴力，再問「重複算了什麼」
最直覺：對每個 i，往右掃到第一個更暖就停。時間約 O(n²)。

慢在哪裡？很多 (i, j) 的關係其實可以從左到右掃一次就決定：一旦你在某天 j 看到夠暖的溫度，你同時知道「左邊還在等更暖的那些天」裡，誰的「下一個更暖」就是 j。

所以關鍵不是「每個 i 都往右找」，而是：當我走到第 i 天時，能不能一次幫前面好幾天填答案？

怎麼想到用 stack
想像只從左往右讀溫度：

若今天比昨天冷或一樣，「昨天那天的下一個更暖」還沒出現，我們先記住昨天（以及可能一串遞減的日子）還在等。
若今天變暖了，不只可能解掉「昨天」，還可能連續解掉更左邊、溫度一路遞減堆起來的那些天——因為它們都在等「右邊第一個比自己大的」，而今天若比 stack 頂上那天暖，依遞減順序，也會比更左邊那些（在 stack 裡更靠下的）先被滿足……實際上標準寫法是：stack 從底到頂對應的索引，溫度是遞減的；當 temperatures[i] 大於「頂端那一天」的溫度時，頂端那一天的第一個更暖就是 i。
需要一種結構：

只關心「還沒找到下一個更暖」的日子；
且能快速比較「今天是否比『最近還在等的那一天』更暖」，若可以，就幫那一天填答案並移除，可能重複直到不能為止。
後進先出剛好符合「先處理最近的一天，一路往左清」的順序，所以自然會想到 stack 存「還在等待的日子的索引」。這類「維護單調性 + 遇到突破就 pop」的套路，就是 monotonic stack（單調棧）。

演算法在幹嘛（逐步）
初始化
result 全 0；stack 空。預設「還沒填的都當作 0」（右邊沒有更暖）。

對每個 i 從 0 掃到 n-1
代表「我們已經看到第 i 天的溫度」。

內層 while：只要 stack 不空，且今天比「stack 頂端那一天」暖

對頂端索引 prev 來說，i 就是右邊第一個更暖（因為中間比 prev 冷或等溫的日子若還在 stack 裡，會先被 pop 掉；單調性保證了這點）。
設 result[prev] = i - prev（等幾天）。
pop，繼續看下一個還在等的，直到今天不夠暖或 stack 空。
stack.Push(i)
第 i 天自己也還不知道右邊何時更暖，先加入「等待隊伍」。

迴圈結束後
stack 裡剩下的索引，右邊沒有更暖，result 維持 0。

複雜度直覺
每個索引最多進 stack 一次、出 stack 一次，總共 O(n)，比暴力 O(n²) 好。

一句話記憶
從左往右走，stack 記「還在等右邊第一個更暖的日子」；今天夠暖就從頂開始連續幫這些日子結案。 這就是為什麼這題和「下一個更大元素」類題目都長同一張臉。    
    */
    public int[] GetDailyTemperaturesWithStack(int[] temperatures)
    {
        if (temperatures.Length == 1)
        {
            return [0];
        }
        
        var stack = new Stack<int>();
        var result = new int[temperatures.Length]; // [0,0,0,0,0,0,0,0]
        for (int i = 0; i < temperatures.Length; i++)
        {
            // stack 不為空，且今天比「stack 頂端那一天」暖
            while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
            {
                var prevIndex = stack.Pop(); // pop stack 頂端那一天的索引
                result[prevIndex] = i - prevIndex; //（等幾天）。
            }
            stack.Push(i); // stack push 今天索引
        }
        return result;
    }
}