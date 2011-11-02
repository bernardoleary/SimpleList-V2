package com.infostructure.simplelist.utils;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.lang.reflect.Type;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.lang.String;

import android.content.Context;
import android.util.Log;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import com.infostructure.simplelist.model.SimpleList;
import com.infostructure.simplelist.model.SimpleListItem;
import com.infostructure.simplelist.model.UserCredentials;
import com.infostructure.simplelist.model.dto.SimpleListDto;
import com.infostructure.simplelist.model.dto.SimpleListItemDto;

public class DataAccess {

	// http://developer.android.com/guide/appendix/faq/commontasks.html#localhostalias
	// use the alias "10.0.2.2" instead of "localhost" or "127.0.0.1"
	
	/* == */
	/* TEST */
	//private final String URL = "http://10.0.2.2:5900/";
	/* == */
	/* PROD */
	/* == */
	private final String URL = "http://www.infostructure.co.nz/SimpleList/";
	/* == */
	
	private final String SIMPLE_LIST = "SimpleList";
	private final String SIMPLE_LIST_ITEM = "SimpleListItem";
	private final String SIMPLE_LIST_ITEM_TOGGLE_DONE = SIMPLE_LIST_ITEM + "/ToggleDone";
	private final String FILENAME = "settings";
	private Context applicationContext = null;
	private Mapper mapper = null;
	
	public DataAccess(Context applicationContext) {
		this.applicationContext = applicationContext;
		this.mapper = new Mapper();
	}
	
	public List<SimpleList> getSimpleLists() throws Exception {
		
		// collect user credentials from external storage
		UserCredentials credentials = getUserCredentials();
		String userName = credentials.getUserName();
		String password = credentials.getPassword();
		
		String simpleListUrl = URL + SIMPLE_LIST;
		WebService webService = new WebService(simpleListUrl);

		//Pass the parameters if needed , if not then pass dummy one as follows
		Map<String, String> params = new HashMap<String, String>();
		params.put("userName", userName);
		params.put("password", password);

		//Get JSON response from server the "" are where the method name would normally go if needed example
		String response = webService.webGet("", params);

		try
		{
			//Parse Response into our object
			Type collectionType = new TypeToken<List<SimpleListDto>>(){}.getType();
			List<SimpleListDto> simpleListDtos = new Gson().fromJson(response, collectionType);
			return mapper.SimpleListDtosToSimpleLists(simpleListDtos);
		}
		catch(Exception e)
		{
			Log.d("Error: ", e.toString());
			return null;
		}
	}

	public List<SimpleListItem> getSimpleListItems(int simpleListId) throws Exception {
		
		// collect user credentials from external storage
		UserCredentials credentials = getUserCredentials();
		String userName = credentials.getUserName();
		String password = credentials.getPassword();
		
		String simpleListUrl = URL + SIMPLE_LIST_ITEM;
		WebService webService = new WebService(simpleListUrl);

		//Pass the parameters if needed , if not then pass dummy one as follows
		Map<String, String> params = new HashMap<String, String>();
		params.put("userName", userName);
		params.put("password", password);
		params.put("simpleListId", Integer.toString(simpleListId));

		//Get JSON response from server the "" are where the method name would normally go if needed example
		String response = webService.webGet("", params);

		try
		{
			//Parse Response into our object
			Type collectionType = new TypeToken<List<SimpleListItemDto>>(){}.getType();
			List<SimpleListItemDto> simpleListItemDtos = new Gson().fromJson(response, collectionType);
			return mapper.SimpleListItemDtosToSimpleListItems(simpleListItemDtos);
		}
		catch(Exception e)
		{
			Log.d("Error: ", e.toString());
			return null;
		}
	}

	public String toggleSimpleListItemDone(int simpleListId, int simpleListItemId) throws Exception {
		
		// collect user credentials from external storage
		UserCredentials credentials = getUserCredentials();
		String userName = credentials.getUserName();
		String password = credentials.getPassword();
		
		String simpleListUrl = URL + SIMPLE_LIST_ITEM_TOGGLE_DONE;
		WebService webService = new WebService(simpleListUrl);

		//Pass the parameters if needed , if not then pass dummy one as follows
		Map<String, Object> params = new HashMap<String, Object>();
		params.put("userName", userName);
		params.put("password", password);
		params.put("simpleListId", simpleListId);
		params.put("simpleListItemId", simpleListItemId);

		//Get JSON response from server the "" are where the method name would normally go if needed example
		return webService.webInvoke("", params);
	}
	
	public UserCredentials getUserCredentials() throws Exception {
		
		// read the file in
		byte[] buffer = new byte[1000];
		FileInputStream fileInputStream = null;
		try {
			fileInputStream = applicationContext.openFileInput(FILENAME);
			fileInputStream.read(buffer);
		} finally {		
			if (fileInputStream != null)
				fileInputStream.close();
		}
		
		// set user credentials and return
		UserCredentials userCredentials = new UserCredentials();
		String credentials = new String(buffer);
		userCredentials.setUserName(credentials.split("\n")[0]);
		userCredentials.setPassword(credentials.split("\n")[1]);
		return userCredentials;
	}
	
	public void setUserCredentials(UserCredentials userCredentials) throws Exception {
		
		// set the credentials and store them
		FileOutputStream fileOutputStream = null;
		try {
			fileOutputStream = applicationContext.openFileOutput(FILENAME, Context.MODE_PRIVATE);
			fileOutputStream.write((userCredentials.getUserName() + "\n" + userCredentials.getPassword() + "\n").getBytes());
		} finally {		
			if (fileOutputStream != null)
				fileOutputStream.close();
		}
	}
}
