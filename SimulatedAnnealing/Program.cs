// See https://aka.ms/new-console-template for more information
List<List<string>> Wo = new List<List<string>>();//wo, ct_,1, ct_m2, ct_m3, due time

Wo.Add(new List<string> { "wo1", "10", "20", "30", "010"});
Wo.Add(new List<string> { "wo2", "20", "50", "15", "020"});
Wo.Add(new List<string> { "wo3", "05", "30", "10", "015"});
Wo.Add(new List<string> { "wo4", "30", "10", "05", "050"});
Wo.Add(new List<string> { "wo5", "20", "10", "50", "100"});
Console.WriteLine("Delay at first: "+ GetTotalDelayTime(Wo));
int tryTimes = 2000;

while (tryTimes >= 0)
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
        Console.WriteLine(GetTotalDelayTime(ListSwap(Wo, x, y)) + " is less than " + GetTotalDelayTime(Wo));
        Wo = ListSwap(Wo, x, y);
    }
    tryTimes--;
}

Console.WriteLine("final result: " + GetTotalDelayTime(Wo));
for (int i = 0; i < Wo.Count; i++)
{
    for (int j = 0; j < Wo[i].Count; j++)
    {
        Console.Write(Wo[i][j]+" | ");
    }
    Console.WriteLine("");
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
    for (int i = 0; i < wo.Count; i++)//each wo
    {
        List<int> eachStationTime = new List<int> {0,0,0};
        for (int j = i; j >= 0; j--)//for previous wo
        {
            
            for (int k = 1; k <= 3; k++)//for each station time until now
            {
                eachStationTime[k-1] += int.Parse(wo[j][k]);
            }
            
        }
        int x = Max(eachStationTime) > int.Parse(wo[i][4]) ? Max(eachStationTime) - int.Parse(wo[i][4]) : 0;
        //Console.WriteLine(x);
        res += x;
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
