// See https://aka.ms/new-console-template for more information
List<List<string>> Wo = new List<List<string>>();//wo, ct_,1, ct_m2, ct_m3, due time

Wo.Add(new List<string> { "wo1", "10", "20", "30", "010"});
Wo.Add(new List<string> { "wo2", "20", "50", "15", "020"});
Wo.Add(new List<string> { "wo3", "05", "30", "10", "015"});
Wo.Add(new List<string> { "wo4", "30", "10", "05", "050"});
Wo.Add(new List<string> { "wo5", "20", "10", "50", "100"});
Console.WriteLine("Delay at first: "+ GetTotalDelayTime(Wo));
int tryTimes = 100000;
int counter = 1;
while (counter <= tryTimes)
{
    Random r = new Random();
    int x = r.Next(0, Wo.Count);
    int y;
    do
    {
        y = r.Next(0, Wo.Count);
    } while (y == x);

    if (GetTotalDelayTime(ListSwap(Wo, x, y)) < GetTotalDelayTime(Wo))
    {
        Console.WriteLine(GetTotalDelayTime(ListSwap(Wo, x, y)) + " is less than " + GetTotalDelayTime(Wo)+" at "+ counter + " rounds");
        for (int i = 0; i < Wo.Count; i++)
        {
            for (int j = 0; j < Wo[i].Count; j++)
            {
                Console.Write(Wo[i][j] + " | ");
            }
            Console.WriteLine("");
        }
        Wo = ListSwap(Wo, x, y);
    }
    counter++;
}






List<List<string>> ListSwap(List<List<string>> source, int a, int b)
{
    List<List<string>> newList = new List<List<string>>();
    newList = source.ToList();
    List<string> tmp = new List<string>();
    tmp = newList[a];
    newList[a] = newList[b];
    newList[b] = tmp;
    /*
    for (int i = 0; i < source.Count; i++)
    {
        Console.Write(source[i][0]);
    }
    Console.WriteLine("");
    for (int i = 0; i < newList.Count; i++)
    {
        Console.Write(newList[i][0]);
    }
    */
    return newList;
}

int GetTotalDelayTime(List<List<string>> wo)
{
    int res = 0;
    int tmp;
    int dueTime;
    for (int i = 0; i < wo.Count; i++)//each wo
    {
        dueTime = int.Parse(wo[i][^1]);
        List<int> tmpCTList = new();
        for (int j = 1; j < wo[i].Count - 1; j++)
        {
            if (int.Parse(wo[i][j]) != 0)
            {
                tmp = 0;
                for (int k = i - 1; k >= 0; k--)
                {
                    tmp += int.Parse(wo[k][j]);
                }
                tmpCTList.Add(tmp);
                tmpCTList.Add(int.Parse(wo[i][j]));
            }
        }

        int preTime = 0;
        for (int l = 0; l < tmpCTList.Count; l += 2)//pre, ct
        {
            preTime = preTime > tmpCTList[l] ? preTime : tmpCTList[l];
            preTime += tmpCTList[l + 1];
        }



        preTime = preTime > dueTime ? preTime - dueTime : 0;
        res += preTime;
    }
    //Console.WriteLine(res); 
    return res;
}

int Max(List<int> a)
{
    int res = a[0];
    for (int i = 1; i < a.Count; i++)
    {
        if (a[i] > res)
        {
            res = a[i];
        }
    }
    return res;
}
