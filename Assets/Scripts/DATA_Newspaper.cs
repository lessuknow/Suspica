using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public static class DATA_Newspaper {

    //takes in 2 papers an sets their values to stuff dependent on the day. Returns 2 papers (Swan -> Peacock) as results.
    public static List<Newspaper_Data> SetPapers(Newspaper_Handler l, Newspaper_Handler r, int day)
    {
        List<Newspaper_Data> ret = new List<Newspaper_Data>();
        //neutral -> swans -> peacocks
        int ignore = Random.Range(0, 2);
        Newspaper_Data res_swan = new Newspaper_Data();
        Newspaper_Data res_pea = new Newspaper_Data();
        switch(day)
        {
            case 1:
                l.UpdatePaper("School Near Cobra Den Falls Victim to Attacks", 
                    0.5f, 0.4f, 0.4f, 500, 0f, 0.7f, "cobra",
                    new List<string>()
                    {
                        "Very interesting information contained",
                        "Not too sure about how reliable the information is",
                    }
                    );
                r.UpdatePaper("Cobras Attack Children, Calls for Action Rise", 
                    0.6f, 0.3f, 0.4f, 800, 0.8f, 0f, "cobra",
                    new List<string>()
                    {
                        "Had to exaggerate amount of people wanting revenge to get a good headline",
                        "Title should bring in more profits then usual",
                        "Some birds are going to be offended, but that might be good for attention"
                    }
                    );
                res_pea.SetContents("Parents Demand Rezoned School District after Recent Attacks", 0, 0, 0, 0, 0, 0, "cobra");
                res_swan.SetContents("School Begins Process of Cobra Extermination After Recent Attacks", 0, 0, 0, 0, 0, 0, "cobra");
                break;
            case 2:
                l.UpdatePaper("A Gruesome Display: Swan Spites Herbivore Protestors By Devouring Frog", 
                    0.8f, 0.2f, 0.8f, 1200, 0f, 1f, "protestor",
                    new List<string>()
                    {
                        "Good strong headline should get us a lot of money",
                        "Some birds are definately going to be upset with us",
                        "High shock value should get a lot of attention as well"
                    }
                    );
                r.UpdatePaper("Pro-Herbivore Protestors Publicly Shame Swan For Eating Habits", 
                    0.6f, 0.55f, 0.2f, 500, 0.9f, 0f, "protestor",
                    new List<string>()
                    {
                        "Should get money from those Swans",
                        "Another protest another day; maybe this one will get some attention for once?"
                    }
                    );
                res_pea.SetContents("Violence Ensues as Herbivore Crowd Mobs Non-Herbivore Restaurant", 0, 0, 0, 0, 0, 0, "protestor");
                res_swan.SetContents("Violence Ensues as Herbivore Protest Clashes with Omnivore Citizens", 0, 0, 0, 0, 0, 0, "protestor");
                break;
            case 3:
                l.UpdatePaper("Swans Continue to Refuse Entry to Migrating Birds", 
                    0.8f, 0.7f, 0.3f, 600, 0f, 1f, "migrate",
                    new List<string>()
                    {
                        "Nothing new; Swan's stance hasn't changed at all",
                        "Throws blame towards the Swans; should cause lots of drama and get lots of attention"
                    }
                    );
                r.UpdatePaper("Influx of migrating Birds Drains Local Resources",
                    0.7f, 0.4f, 0.7f, 900, 0.7f, 0f, "migrate",
                    new List<string>()
                    {
                        "Draining local resources is a pretty grand overstatement",
                        "Should attract a lot of readers with that exaggeration however"
                    }
                    );
                res_pea.SetContents("Rates of Illegal Migration Rise as Citizens Open Homes to Foreign Birds", 0, 0, 0, 0, 0, 0, "migrate");
                res_swan.SetContents("Border Patrol Doubles down Due to National Pressure", 0, 0, 0, 0, 0, 0, "migrate");
                break;
            case 4:
                l.UpdatePaper("Better Home Security: The Best Defense Against Cobras",
                    0.6f, 0.9f, 0.2f, 400, 0f, 0.7f, "birdhouse",
                    new List<string>()
                    {
                        "Should make a little money",
                        "Nothing stands out with this article one way or another"
                    }
                    );
                r.UpdatePaper("Death Count Rises as Cobra Population Remains Unchecked",
                    0.9f, 0.4f, 0.6f, 800, 1f, 0f, "birdhouse",
                    new List<string>()
                    {
                        "Should attract a good deal of attention",
                        "Lots of money to be made here",
                        "Both Swans and Peacocks should find this article interesting"
                    }
                    );
                res_pea.SetContents("Cost of Home Security Units at All Time High", 0, 0, 0, 0, 0, 0, "birdhouse");
                res_swan.SetContents("Kettle of Hawks Arrested for Illegal Cobra Hunting", 0, 0, 0, 0, 0, 0, "birdhouse");
                break;

            case 5:
                l.UpdatePaper("Suspica Applauds Formerly Homeless Pigeon for Hard Work",
                    0.3f, 1f, 0.2f, 400, 0f, 0.5f, "seedkitchen",
                    new List<string>()
                    {
                        "Feed good article",
                        "Not very exciting, but is honest."
                    }
                    );
                r.UpdatePaper("Recent Increase in Need of Seed Kitchens Sparks Question About Minimum Wage",
                    0.6f, 0.6f, 0.5f, 800, 0.7f, 0f, "seedkitchen",
                    new List<string>()
                    {
                        "Adds a little controversy to the article",
                        "Some people will be upset with inserting politics into this article"
                    }
                    );
                res_pea.SetContents("Lack of Funding Causes Shut Down of Local Seed Kitchen", 0, 0, 0, 0, 0, 0, "seedkitchen");
                res_swan.SetContents("Seed Kitchen Calls for Volunteers, Struggles to Pay Minimum Wage for Workers", 0, 0, 0, 0, 0, 0, "seedkitchen");
                break;

            case 6:
                l.UpdatePaper("Citizens’ Tax Dollars to be Used for Unnecessary Draft",
                    0.8f, 0.5f, 0.8f, 900, 0f, 1f, "army",
                    new List<string>()
                    {
                        "Opinion piece should bring in money",
                        "Due to bias somewhat innately misleading"
                    }
                    );
                r.UpdatePaper("Securing the Future of Our Nation: National Draft Waits for Government Approval",
                    0.7f, 0.3f, 0.6f, 600, 0.9f, 0f, "army",
                    new List<string>()
                    {
                        "Opinion piece should bring in money",
                        "Heavy bias is present throughout the entire article"
                    }
                    );
                res_pea.SetContents("Males Against Draft Coalition March on Capitol", 0, 0, 0, 0, 0, 0, "army");
                res_swan.SetContents("Males Against Draft Coalition March on Capitol", 0, 0, 0, 0, 0, 0, "army");
                break;

            case 7:
                l.UpdatePaper("Art Gallery Raises Interest in Local Artists",
                    0.4f, 0.85f, 0.4f, 400, 0f, 0.5f, "gallery",
                    new List<string>()
                    {
                        "Feel good article",
                        "Peacocks will tend to flock towards these articles"
                    }
                    );
                r.UpdatePaper("Tax Dollars Used in Construction of Needless Gallery",
                    0.8f, 0.5f, 0.6f, 600, 0.9f, 0f, "gallery",
                    new List<string>()
                    {
                        "Swans will enjoy this piece more then others",
                        "New take on a boring article should make the article more interesting"
                    }
                    );
                res_pea.SetContents("Local Art Shops Thrive on Heels of Gallery Opening", 0, 0, 0, 0, 0, 0, "gallery");
                res_swan.SetContents("Volunteers Needed for Repairing Gallery Following Vandalism", 0, 0, 0, 0, 0, 0, "gallery");
                break;


        }
        ret.Add(res_swan);
        ret.Add(res_pea);

        l.ApplyUpdateToObject();
        r.ApplyUpdateToObject();

        return ret;
    }


}
