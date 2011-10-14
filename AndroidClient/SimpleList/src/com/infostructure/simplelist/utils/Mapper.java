package com.infostructure.simplelist.utils;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import com.infostructure.simplelist.model.SimpleList;
import com.infostructure.simplelist.model.SimpleListItem;
import com.infostructure.simplelist.model.dto.SimpleListDto;
import com.infostructure.simplelist.model.dto.SimpleListItemDto;

public class Mapper {
	
	public SimpleList SimpleListDtoToSimpleList(SimpleListDto simpleListDto)
    {
        SimpleList simpleList = new SimpleList();
        simpleList.setId(simpleListDto.ID);
        simpleList.setName(simpleListDto.Name);
        simpleList.setUserId(simpleListDto.UserID);
        simpleList.setAllDone(simpleListDto.AllDone);
        simpleList.setDateAdded(parseDotNetJsonDate(simpleListDto.DateAdded));
        return simpleList;
    }

    public SimpleListItem SimpleListItemDtoToSimpleListItem(SimpleListItemDto simpleListItemDto)
    {
        SimpleListItem simpleListItem = new SimpleListItem();
        simpleListItem.setId(simpleListItemDto.ID);
        simpleListItem.setDone(simpleListItemDto.Done);
        simpleListItem.setDescription(simpleListItemDto.Description);
        simpleListItem.setSimpleListID(simpleListItemDto.SimpleListID);
        return simpleListItem;
    }

    public List<SimpleListItem> SimpleListItemDtosToSimpleListItems(List<SimpleListItemDto> simpleListItemDtos)
    {
    	List<SimpleListItem> simpleListItems = new ArrayList<SimpleListItem>();
        for (int i = 0; i < simpleListItemDtos.size(); i++)
        	simpleListItems.add(SimpleListItemDtoToSimpleListItem(simpleListItemDtos.get(i)));
        return simpleListItems;
    }

    public List<SimpleList> SimpleListDtosToSimpleLists(List<SimpleListDto> simpleListDtos)
    {
    	List<SimpleList> simpleLists = new ArrayList<SimpleList>();
        for (int i = 0; i < simpleListDtos.size(); i++)
        	simpleLists.add(SimpleListDtoToSimpleList(simpleListDtos.get(i)));
        return simpleLists;
    }
    
    public Date parseDotNetJsonDate(String jsonDate) {
    	String tempDate = "";
    	for (int i = 0; i < jsonDate.length(); i++)
    		if (Character.isDigit(jsonDate.charAt(i)))
    			tempDate += jsonDate.charAt(i);
    	Date date = new Date(Long.parseLong(tempDate.trim()));
    	return date;
    }
}
