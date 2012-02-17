package com.infostructure.simplelist.utils;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.lang.reflect.Type;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.lang.String;

import android.content.Context;
import android.content.SharedPreferences;
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
	//private final String URL = "http://10.0.2.2:5900/ApiService";
	/* == */
	/* PROD */
	/* == */
	private final String URL = "http://www.smplifi.com/ApiService";
	/* == */
	
	private final String PREFS_FILE_NAME = "prefs";
	private final String FORWARD_SLASH = "/";
	private final String SIMPLE_LIST = "SimpleList";
	private final String SIMPLE_LIST_ITEM = "SimpleListItem";	
	private final String SETTINGS_FILE_NAME = "settings";
	private final String POPULATE_SUB_STRUCTURES = "populateSubStructures";
	private final String USER_NAME = "userName";
	private final String PASSWORD = "password";
	private Context applicationContext = null;
	private Mapper mapper = null;
	
	public DataAccess(Context applicationContext) {
		this.applicationContext = applicationContext;
		this.mapper = new Mapper();
	}
	
	public List<SimpleList> getSimpleLists() throws Exception {
		
		String simpleListUrl = URL + FORWARD_SLASH + SIMPLE_LIST;
		WebService webService = new WebService(simpleListUrl);

		//Pass the parameters if needed , if not then pass dummy one as follows
		Map<String, String> params = getUserCredentialsHashMap();
		params.put(POPULATE_SUB_STRUCTURES, "false");

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
		
		String simpleListUrl = URL + FORWARD_SLASH + SIMPLE_LIST + FORWARD_SLASH + simpleListId;
		WebService webService = new WebService(simpleListUrl);

		//Get JSON response from server the "" are where the method name would normally go if needed example
		String response = webService.webGet("", getUserCredentialsHashMap());

		try
		{
			//Parse Response into our object
			Type collectionType = new TypeToken<SimpleListDto>(){}.getType();
			SimpleListDto simpleListDto = new Gson().fromJson(response, collectionType);
			return mapper.SimpleListItemDtosToSimpleListItems(simpleListDto.SimpleListItems);
		}
		catch(Exception e)
		{
			Log.d("Error: ", e.toString());
			return null;
		}
	}

	public String createSimpleList(String name) throws Exception {
		
		String simpleListUrl = URL + FORWARD_SLASH + SIMPLE_LIST;
		WebService webService = new WebService(simpleListUrl);
		
		// Pass data if needed.
		SimpleListDto simpleListDto = new SimpleListDto();
		simpleListDto.Name = name;
		simpleListDto.setIsWrapped(false);
		
		//Get JSON response from server the "" are where the method name would normally go if needed example
		return webService.webInvoke("", getUserCredentialsHashMap(), simpleListDto);
	}
	
	public String createSimpleListItem(int simpleListId, String description) throws Exception {
		
		String simpleListUrl = URL + FORWARD_SLASH + SIMPLE_LIST + FORWARD_SLASH + simpleListId + FORWARD_SLASH + SIMPLE_LIST_ITEM;
		WebService webService = new WebService(simpleListUrl);
		
		// Pass data if needed.
		SimpleListItemDto simpleListItemDto = new SimpleListItemDto();
		simpleListItemDto.SimpleListID = simpleListId;
		simpleListItemDto.Description = description;
		simpleListItemDto.setIsWrapped(true);
		
		//Get JSON response from server the "" are where the method name would normally go if needed example
		return webService.webInvoke("", getUserCredentialsHashMap(), simpleListItemDto);
	}

	public String toggleSimpleListItemDone(int simpleListId, int simpleListItemId) throws Exception {
		
		String simpleListUrl = URL + FORWARD_SLASH + SIMPLE_LIST + FORWARD_SLASH + simpleListId + FORWARD_SLASH + SIMPLE_LIST_ITEM + FORWARD_SLASH + simpleListItemId;
		WebService webService = new WebService(simpleListUrl);

		//Get JSON response from server the "" are where the method name would normally go if needed example
		return webService.webPut("", getUserCredentialsHashMap(), null);
	}
	
	public String deleteSimpleListItem(int simpleListId, int simpleListItemId) throws Exception {
		
		String simpleListUrl = URL + FORWARD_SLASH + SIMPLE_LIST + FORWARD_SLASH + simpleListId + FORWARD_SLASH + SIMPLE_LIST_ITEM + FORWARD_SLASH + simpleListItemId;
		WebService webService = new WebService(simpleListUrl);

		//Get JSON response from server the "" are where the method name would normally go if needed example
		return webService.webDelete("", getUserCredentialsHashMap());
	}
	
	public UserCredentials getUserCredentials() throws Exception {
	
		// set user credentials and return
		UserCredentials userCredentials = new UserCredentials();
		SharedPreferences settings = this.applicationContext.getSharedPreferences(PREFS_FILE_NAME, 0);
		userCredentials.setUserName(settings.getString("userName", ""));
		userCredentials.setPassword(settings.getString("password", ""));
		return userCredentials;
       
       /*
		// read the file in
		byte[] buffer = new byte[1000];
		FileInputStream fileInputStream = null;
		try {
			fileInputStream = applicationContext.openFileInput(SETTINGS_FILE_NAME);
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
		*/
	}
	
	public void setUserCredentials(UserCredentials userCredentials) throws Exception {
		
		// We need an Editor object to make preference changes.
		SharedPreferences settings = this.applicationContext.getSharedPreferences(PREFS_FILE_NAME, 0);
		SharedPreferences.Editor editor = settings.edit();
		editor.putString("userName", userCredentials.getUserName());
		editor.putString("password", userCredentials.getPassword());
		
		// Commit the edits!
		editor.commit();
		
		/*
		// set the credentials and store them
		FileOutputStream fileOutputStream = null;
		try {
			fileOutputStream = applicationContext.openFileOutput(SETTINGS_FILE_NAME, Context.MODE_PRIVATE);
			fileOutputStream.write((userCredentials.getUserName() + "\n" + userCredentials.getPassword() + "\n").getBytes());
		} finally {		
			if (fileOutputStream != null)
				fileOutputStream.close();
		}
		*/
	}
	
	private Map<String, String> getUserCredentialsHashMap() throws Exception {
		
		// collect user credentials from external storage
		UserCredentials credentials = getUserCredentials();
		String userName = credentials.getUserName();
		String password = credentials.getPassword();
		
		// Pass the parameters if needed , if not then pass dummy one as follows
		Map<String, String> params = new HashMap<String, String>();
		params.put(USER_NAME, userName);
		params.put(PASSWORD, password);
		
		return params;
	}
}
