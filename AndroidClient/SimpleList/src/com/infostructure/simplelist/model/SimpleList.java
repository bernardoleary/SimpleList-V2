package com.infostructure.simplelist.model;

import java.util.Date;

public class SimpleList {
	
	private int id;
	private String name;
	private Date dateAdded;
	private java.util.List<SimpleListItem> simpleListItems; 
	private boolean allDone;
	private int userId;
	
	public int getId() {
		return id;
	}
	
	public void setId(int id) {
		this.id = id;
	}
	
	public String getName() {
		return name;
	}
	
	public void setName(String name) {
		this.name = name;
	}
	
	public Date getDateAdded() {
		return dateAdded;
	}
	
	public void setDateAdded(Date dateAdded) {
		this.dateAdded = dateAdded;
	}

	public java.util.List<SimpleListItem> getSimpleListItems() {
		return simpleListItems;
	}
	
	public void setAllDone(java.util.List<SimpleListItem> simpleListItems) {
		this.simpleListItems = simpleListItems;
	}
	
	public Boolean getAllDone() {
		return allDone;
	}
	
	public void setAllDone(Boolean allDone) {
		this.allDone = allDone;
	}

	public int getUserId() {
		return userId;
	}
	
	public void setUserId(int userId) {
		this.userId = userId;
	}
}
