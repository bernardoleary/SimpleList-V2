package com.infostructure.simplelist;
import java.util.List;

import com.infostructure.simplelist.R;
import com.infostructure.simplelist.abstractions.BaseSimpleListActivity;
import com.infostructure.simplelist.custom.SimpleListAdapter;
import com.infostructure.simplelist.model.SimpleList;
import com.infostructure.simplelist.utils.DataAccess;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

public class SimpleListActivity extends BaseSimpleListActivity  {
	
    /** Called when the activity is first created. */
	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		
		// setup our data access
		dataAccess = new DataAccess(getApplicationContext());
		
		// initialise UI
		try {
			initControls();
		} catch (Exception e) {
			Log.d("Error: ", e.toString());
			return;
		}
	}
	
	@Override
	public void initControls() throws Exception {
		
		// populate the simplelists structure
		List<SimpleList> simpleLists;
		try {
			simpleLists = dataAccess.getSimpleLists();
		} catch (Exception e) {
			Toast.makeText(getApplicationContext(), e.toString(), Toast.LENGTH_LONG).show();
			return;
		}
		
		String[] array = new String[simpleLists.size()];
		
		for (int i=0; i<simpleLists.size(); i++)
			array[i] = simpleLists.get(i).getName();
		
		ArrayAdapter<SimpleList> adapter = new SimpleListAdapter(this, R.layout.custom_list_item, simpleLists);
		setListAdapter(adapter);
		
		ListView lv = getListView();
		lv.setTextFilterEnabled(true);
		
		lv.setOnItemClickListener(new OnItemClickListener() {
			@Override
			public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
				// When clicked, transfer to the simple list items
				SimpleList simpleList = (SimpleList)parent.getItemAtPosition(position);
				BaseSimpleListActivity.setCurrentSimpleListId(simpleList.getId());
				intent = new Intent(getApplicationContext(), SimpleListItemActivity.class);
				startActivity(intent);
		    }
		});
	}
}