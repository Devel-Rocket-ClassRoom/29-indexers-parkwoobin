using System;
using System.Collections;

// README.md를 읽고 아래에 코드를 작성하세요.

Catalog catalog = new Catalog();    // 1. 기본 인덱서 예제
Console.WriteLine(catalog[0]);  // 0: 짝수 반환
Console.WriteLine(catalog[1]);  // 1: 홀수 반환
Console.WriteLine(catalog[2]);  // 2: 짝수 반환

Car car = new Car(3);   // 2. 배열 필드를 감싸는 인덱서
car[0] = "CLA";
car[1] = "CLS";
car[2] = "AMG";

for (int i = 0; i < car.Length; i++)
{
    Console.WriteLine(car[i]);
}

Week week = new Week(3);   // 3. 요일 클래스 예제
week[0] = "일요일";
week[1] = "월요일";
week[2] = "화요일";

for (int i = 0; i < week.Length; i++)
{
    Console.WriteLine(week[i]);
}

NickName nickName = new NickName();   // 4. 문자열 인덱서
nickName["홍길동"] = "RedPlus";
nickName["김철수"] = "BlueStar";

Console.WriteLine($"{nickName["홍길동"]}, {nickName["김철수"]}");  // RedPlus, BlueStar

MultiIndexer multiIndexer = new MultiIndexer();   // 5. 다중 인덱서 예제
multiIndexer[0] = "첫 번째 값";
multiIndexer["name"] = "홍길동";
multiIndexer["city"] = "서울";

Console.WriteLine($"multi[0] = {multiIndexer[0]}");  // 첫 번째 값
Console.WriteLine($"multi[\"name\"] = {multiIndexer["name"]}");  // 홍길동
Console.WriteLine($"multi[\"city\"] = {multiIndexer["city"]}");  // 서울

Example example = new Example();   // 6. 인덱서와 속성의 비교
example.Name = "홍길동";
example[0] = "첫 번째";
example[1] = "두 번째";
Console.WriteLine($"{example.Name}");
Console.WriteLine($"{example[0]}, {example[1]}");


class Catalog   // 1. 기본 인덱서 예제
{
    public string this[int index]
    {
        get
        {
            return (index % 2 == 0) ? $"{index}: 짝수 반환" : $"{index}: 홀수 반환";
        }
    }
}

class Car   // 2. 배열 필드를 감싸는 인덱서
{
    public string[] _names;
    public Car(int Length)
    {
        _names = new string[Length];
    }
    public int Length
    {
        get { return _names.Length; }
    }

    public string this[int index]
    {
        get { return _names[index]; }
        set { _names[index] = value; }
    }
}

class Week   // 3. 요일 클래스 예제
{
    private string[] _days;

    public Week()
    {
        Length = 7;
        _days = new string[Length];
    }
    public Week(int length)
    {
        Length = length;
        _days = new string[Length];
    }
    public int Length { get; private set; }
    public string this[int index]
    {
        get { return _days[index]; }
        set { _days[index] = value; }
    }
}

class NickName   // 4. 문자열 인덱서
{
    private Hashtable _names = new Hashtable();
    public string this[string key]
    {
        get { return _names[key].ToString(); }
        set { _names[key] = value; }
    }
}

class MultiIndexer
{
    private Hashtable _data = new Hashtable();
    // 정수 인덱서
    public string this[int index]
    {
        get { return (string)_data[index]; }
        set { _data[index] = value; }
    }

    // 문자열 인덱서
    public string this[string key]
    {
        get { return (string)_data[key]; }
        set { _data[key] = value; }
    }
}

class Example   // 6. 인덱서와 속성의 비교
{
    private string _name;
    private string[] _items = new string[10];

    public string Name  // 속성(단일 값)
    {
        get { return _name; }
        set { _name = value; }
    }

    public string this[int index]   // 인덱서(배열 형태 접근)
    {
        get { return _items[index]; }
        set { _items[index] = value; }
    }
}