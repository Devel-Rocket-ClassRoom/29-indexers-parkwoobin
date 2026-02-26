using System;
using System.Security.Cryptography;

// README.md를 읽고 코드를 작성하세요.

ScoreBoard scoreBoard = new ScoreBoard(5);
scoreBoard.Register("김민수", 85);
scoreBoard.Register("이지영", 92);
scoreBoard.Register("박서준", 78);


Console.WriteLine($"등록된 학생 수: {scoreBoard._count}\n");
for (int i = 0; i < scoreBoard._count; i++)
{
    Console.WriteLine($"{scoreBoard[i]} 점수: {scoreBoard[scoreBoard[i]]}점");
}
Console.WriteLine();

// 이름으로 점수 조회
string[] queryNames = { "김민수", "이지영", "홍길동" };
for (int i = 0; i < queryNames.Length; i++)
{
    string name = queryNames[i];
    int score = scoreBoard[name];
    Console.WriteLine($"{name} 점수: {score}점");
}
Console.WriteLine();

// "김민수" 점수를 95점으로 수정 후 다시 조회
scoreBoard["김민수"] = 95;
Console.WriteLine($"김민수 수정된 점수: {scoreBoard["김민수"]}점");







class ScoreBoard
{
    public string[] _names;
    public int[] _scores;
    public int _count;
    public int Count => _count;

    public ScoreBoard(int capacity)
    {
        _names = new string[capacity];
        _scores = new int[capacity];
        _count = 0;
    }

    public void Register(string name, int score)
    {
        if (_count >= _names.Length)
        {
            Console.WriteLine("성적표가 가득 찼습니다.");
            return;
        }
        _names[_count] = name;
        _scores[_count++] = score;
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

    public int this[string name]
    {
        get
        {
            for (int i = 0; i < _names.Length; i++)
            {
                if (_names[i] == name)
                {
                    return _scores[i];
                }
            }
            return -1;
        }
        set
        {
            for (int i = 0; i < _names.Length; i++)
            {
                if (_names[i] == name)
                {
                    _scores[i] = value;
                    return;
                }
            }
        }
    }
}
