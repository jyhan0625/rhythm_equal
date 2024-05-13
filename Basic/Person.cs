public class Person
{


    public string Name;
    int age;
    bool Sleeping = false;

    string Talk()
    {

        return "Hello";

    }

    public bool IsSleeping()
    {

        return Sleeping;

    }

    void Sleep()
    {

        if (Sleeping == false) Sleeping = true;

    }

    void WakeUp()
    {

        if (Sleeping) Sleeping = false;

    }

}
