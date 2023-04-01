using System;

public static class APIData
{
	public static string PlayerToken = "UNJDKNJNDJNDJKN";
	private static string API_URL = "http://localhost:80";
	static APIData()
	{

	}

	public static String GetURL(){
		return API_URL;
	}
}
