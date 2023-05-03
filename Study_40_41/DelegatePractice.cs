/*
// DelegateDemo.cs
//[?] 대리자: 영어 단어의 delegate는 "위임하다" 또는 "대신하다"의 뜻
using System;

class DelegateDemo
{
    //[1] 함수 생성 -> 매개 변수도 없고 반환값도 없는 함수
    static void Hi() => Console.WriteLine("안녕하세요.");

    //[2] 대리자 생성 -> 매개 변수도 없고 반환값도 없는 함수를 대신 실행할 대리자
    delegate void SayDelegate();

    static void Main()
    {
        //[A] Hi 함수를 say 이름으로 대신해서 호출
        SayDelegate say = Hi;
        say();

        //[B] Hi 함수를 hi 이름으로 대신해서 호출: 또 다른 모양
        var hi = new SayDelegate(Hi);
        hi();
    }
}

*/

/*
using System;

class AnonymousDelegate
{
    delegate void SayDelegate();
    static void Main()
    {
        // delegate 키워드로 함수를 바로 정의해서 사용
        SayDelegate say = delegate ()
        {
            Console.WriteLine("반갑습니다.");
        };
        say();
    }
}
*/

/*
// Func 대리자
using System;

class FuncDemo
{
    static void Main()
    {
        // [1] int를 입력 받아 0이면 true을 반환
        Func<int, bool> zero = number => number == 0;
        Console.WriteLine(zero(1234 - 1234)); // True

        // [2] int를 입력 받아 1을 더한 값을 반환
        Func<int, int> one = n => n + 1;
        Console.WriteLine(one(1)); // 2

        // [3] int 2개를 입력 받아 더한 값을 반환
        Func<int, int, int> two = (x, y) => x + y;
        Console.WriteLine(two(3, 5)); // 8
    }
}
*/

/*
using System;

class FuncDelegate
{
    static void Main()
    {
        // [1] Add 함수 직접 호출
        Console.WriteLine(Add(3, 5));

        // [2] Func 대리자로 Add 함수 대신 호출: 반환값이 있는 메서드를 대신 호출
        Func<int, int, string> AddDelegate = Add; // Add 메서드를 대신 호출
        Console.WriteLine(AddDelegate(3, 5));

        // [3] 람다식(Lambda): 메서드 -> 무명메서드 -> 람다식으로 줄여서 표현
        Func<int, int, string> AddLambda = (a, b) => (a + b).ToString();
        Console.WriteLine(AddLambda(3, 5));
    }

    /// <summary>
    /// 두 수의 합을 문자열로 반환
    /// </summary>
    static string Add(int a, int b) => (a + b).ToString();
}
*/

using System;

public class ButtonClass
{
    //[1] 이벤트 생성을 위한 대리자 하나 생성
    public delegate void EventHandler(); // 여러 개 메서드 등록 후 호출 가능

    //[2] 이벤트 선언: Click 이벤트 
    public event EventHandler Click;

    //[3] 이벤트 발생 메서드: OnClick 이벤트 처리기(핸들러) 생성
    public void OnClick()
    {
        if (Click != null) // 이벤트에 등록된 값이 있는지 확인(생략 가능)
        {
            Click(); // 대리자 형식의 이벤트 수행
        }
    }
}

class EventDemo
{
    static void Main()
    {
        //[A] Button 클래스의 인스턴스 생성
        ButtonClass btn = new ButtonClass();

        //[B] btn 개체의 Click 이벤트에 실행할 메서드들 등록
        btn.Click += Hi1; // btn.Click += new ButtonClass.EventHandler(Hi1);
        btn.Click += Hi2; // btn.Click += new ButtonClass.EventHandler(Hi2);

        //[C] 이벤트 처리기(발생 메서드)를 통한 이벤트 발생: 다중 메서드 호출
        btn.OnClick();
    }
    static void Hi1() => Console.WriteLine("C#");
    static void Hi2() => Console.WriteLine(".NET");
}
