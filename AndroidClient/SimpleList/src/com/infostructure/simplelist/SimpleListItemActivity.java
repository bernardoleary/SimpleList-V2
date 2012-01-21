package com.infostructure.simplelist;

import java.util.List;

import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemLongClickListener;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.AdapterView.OnItemClickListener;

import com.infostructure.simplelist.abstractions.BaseSimpleListActivity;
import com.infostructure.simplelist.custom.SimpleListItemAdapter;
import com.infostructure.simplelist.model.SimpleListItem;
import com.infostructure.simplelist.utils.DataAccess;

public class SimpleListItemActivity extends BaseSimpleListActivity {
	
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

		// populate the simplelistitems structure
		List<SimpleListItem> simpleListItems;
		try {
			simpleListItems = dataAccess.getSimpleListItems(BaseSimpleListActivity.getCurrentSimpleListId());
		} catch (Exception e) {
			Toast.makeText(getApplicationContext(), e.toString(), Toast.LENGTH_LONG).show();
			return;
		}
		
		String[] array = new String[simpleListItems.size()];
		
		for (int i=0; i<simpleListItems.size(); i++)
			array[i] = simpleListItems.get(i).getDescription();
		
		ArrayAdapter<SimpleListItem> adapter = new SimpleListItemAdapter(this, R.layout.simple_list_item_list_item, simpleListItems);
		setListAdapter(adapter);
		
		ListView lv = getListView();
		lv.setTextFilterEnabled(true);
		
		// Doesn't seem to work?
		lv.setOnItemClickListener(new OnItemClickListener() {
			@Override
			public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
				// When clicked, show a toast with the TextView text
				Toast.makeText(getApplicationContext(), ((TextView) view).getText(),
				Toast.LENGTH_SHORT).show();
		    }
		});
	}

}
