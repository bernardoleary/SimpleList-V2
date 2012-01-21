package com.infostructure.simplelist.model.dto;

public class SimpleListItemDto extends WrappableDto implements JsonSerialisable {

	public SimpleListItemDto() {
		this.wrapName = "simpleListItemViewModel";
	}
	
	public int ID;
	public String Description;
	public boolean Done;
	public int SimpleListID;

	@Override
	public String serialiseToJson() {
		return this.wrapped
			? "{\"" + this.wrapName + "\":{\"Description\":\"" + this.Description + "\",\"SimpleListID\":" + this.SimpleListID + "}}"
			: "{\"Description\":\"" + this.Description + "\",\"SimpleListID\":" + this.SimpleListID + "}";
	}
}
