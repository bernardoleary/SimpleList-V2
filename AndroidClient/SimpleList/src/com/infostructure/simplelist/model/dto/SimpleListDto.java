package com.infostructure.simplelist.model.dto;

import java.util.List;

public class SimpleListDto extends WrappableDto implements JsonSerialisable {

	public SimpleListDto() {
		this.wrapName = "";
	}
	
	public int ID;
	public String Name;
	public String DateAdded;
	public boolean AllDone;
	public int UserID;
	public List<SimpleListItemDto> SimpleListItems;

	@Override
	public String serialiseToJson() {
		// TODO Auto-generated method stub
		return null;
	}
}

