package com.infostructure.simplelist.model.dto;

public class SimpleListItemDto {

	public int ID;
	public String Description;
	public boolean Done;
	public int SimpleListID;

	@Override
	public String toString()
	{
		return "List Item ID: " + ID + " Description: " + Description;
	}
}
