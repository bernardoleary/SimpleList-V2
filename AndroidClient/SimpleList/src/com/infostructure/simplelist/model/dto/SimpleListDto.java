package com.infostructure.simplelist.model.dto;

public class SimpleListDto {

	public int ID;
	public String Name;
	public String DateAdded;
	public boolean AllDone;
	public int UserID;

	@Override
	public String toString()
	{
		return "List ID: " + ID + " Name: " + Name + " Date Added: " + DateAdded;
	}
}

