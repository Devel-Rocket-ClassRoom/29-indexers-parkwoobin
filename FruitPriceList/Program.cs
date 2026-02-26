using System;

// README.md를 읽고 코드를 작성하세요.

FruitPriceList fruitPriceList = new FruitPriceList(5);
fruitPriceList.Add("사과", 1500);
fruitPriceList.Add("바나나", 3000);
fruitPriceList.Add("딸기", 8000);

Console.WriteLine($"등록된 과일 수: {fruitPriceList.Count}개\n");

Console.WriteLine($"사과 가격: {fruitPriceList["사과"]}원");
Console.WriteLine($"바나나 가격: {fruitPriceList["바나나"]}원");
Console.WriteLine($"포도 가격: {fruitPriceList["포도"]}원\n");

for (int i = 0; i < fruitPriceList.Count; i++)
{
    Console.WriteLine($"{i}번: {fruitPriceList[i]}");
}

class FruitPriceList
{
    private string[] _names;
    private int[] _prices;
    private int _count;

    public FruitPriceList(int capacity)
    {
        _names = new string[capacity];
        _prices = new int[capacity];
        _count = 0;
    }

    public int Count
    {
        get { return _count; }
    }

    public void Add(string name, int price)
    {
        if (_count < _names.Length)
        {
            _names[_count] = name;
            _prices[_count] = price;
            _count++;
        }
        else
        {
            Console.WriteLine("가격표가 가득 찼습니다.");
        }
    }

    public int this[string name]
    {
        get
        {
            for (int i = 0; i < _count; i++)
            {
                if (_names[i] == name)
                {
                    return _prices[i];
                }

            }
            return -1;
        }
    }

    public string this[int index]
    {
        get
        {
            if (index >= 0 && index < _count)
            {
                return _names[index];
            }
            return "";
        }
    }
}
