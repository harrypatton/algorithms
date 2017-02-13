public class Solution
{
    public struct People
    {
        public int Height { get; set; }
        public int Number { get; set; }

        public People(int height, int number)
        {
            this.Height = height;
            this.Number = number;
        }
    }

    public int[,] ReconstructQueue(int[,] people)
    {
        var result = new int[0, 0];
        if (people == null)
        {
            return result;
        }

        List<People> peopleList = this.InitPeople(people);

        // sort the people. Tallest people go first. In the same height group, smallest number goes first.
        peopleList.Sort((people1, people2) => 
        {
            // sort by Height in descending order.
            if (people1.Height != people2.Height)
            {
                return people2.Height - people1.Height;
            } else
            {
                // sort by number in ascending order
                return people1.Number - people2.Number;
            }
        });

        List<People> rerrangedPeopleList = new List<People>();
        
        // Iterate on the sorted people list and insert to new list based on Number value.
        foreach(var person in peopleList)
        {
            rerrangedPeopleList.Insert(person.Number, person);
        }

        // Convert the result to multi-dimensional array.
        result = new int[people.GetLength(0), people.GetLength(1)];

        for(int i = 0; i < rerrangedPeopleList.Count; i++)
        {
            result[i, 0] = rerrangedPeopleList[i].Height;
            result[i, 1] = rerrangedPeopleList[i].Number;
        }

        return result;
    }

    private List<People> InitPeople(int[,] people)
    {
        var result = new List<People>();
        for(int i = 0; i < people.GetLength(0); i++)
        {
            result.Add(new People(people[i, 0], people[i, 1]));
        }

        return result;
    }
}
