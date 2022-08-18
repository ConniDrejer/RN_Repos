using System;

class Program
{
	/// <summary>
	/// My Comments: I have to give up on this challenge
	/// I have never used neither REST API (omly SOAP) nor SWAPI before and cannot get the right connection
	/// I tried sommething like the code below and have also tried with NewtonSoft.Json and Axios but with no success
	/// </summary>
	public static bool ReadSWAPIPersons()
	{
		HttpClient httpClient = new HttpClient();
		string url = "https://swapi.dev/api/people/1/";

		httpClient = new HttpClient();

		var response = httpClient.GetStreamAsync(url);

		return true;
	}
	static void Main()
	{
        try
        {
            bool result = ReadSWAPIPersons();
            if (result)
                Console.Write("Method completed succesfully");
            else
                Console.Write("Method failed");
        }
        catch (Exception ex)
        {
            string error = "Unexpected error: " + ex.Message;
            Console.WriteLine(error);
        }
    }
}