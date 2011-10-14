package com.infostructure.simplelist.model;

public class SimpleListItem {
	
	private int id;
	private String description;
	private Boolean done;
	private int simpleListID;
	
	public int getId() {
		return id;
	}
	
	public void setId(int id) {
		this.id = id;
	}
	
	public String getName() {
		return description;
	}
	
	public void setName(String description) {
		this.description = description;
	}
	
	public Boolean getDone() {
		return done;
	}
	
	public void setDone(Boolean done) {
		this.done = done;
	}
	
	public String getDescription() {
		return description;
	}
	
	public void setDescription(String description) {
		this.description = description;
	}
	
	public int getSimpleListID() {
		return simpleListID;
	}
	
	public void setSimpleListID(int simpleListID) {
		this.simpleListID = simpleListID;
	}
}
