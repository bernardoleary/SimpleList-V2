package com.infostructure.simplelist.abstractions;

import com.infostructure.simplelist.R;
import com.infostructure.simplelist.SettingsActivity;
import com.infostructure.simplelist.utils.DataAccess;

import android.app.ListActivity;
import android.content.Intent;
import android.util.Log;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;

public abstract class BaseSimpleListActivity extends ListActivity implements UserInterface {
	protected DataAccess dataAccess = null;
	protected Intent intent = null;
	public static int currentSimpleListId = -1;
	
	public static int getCurrentSimpleListId() {
		return currentSimpleListId;
	}
	
	public static void setCurrentSimpleListId(int currentSimpleListId) {
		BaseSimpleListActivity.currentSimpleListId = currentSimpleListId;
	}
	
	protected void showSettings() {
		intent = new Intent(this.getBaseContext(), SettingsActivity.class);
		startActivity(intent);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
	    MenuInflater inflater = getMenuInflater();
	    inflater.inflate(R.menu.app_menu, menu);
	    return true;
	}
	
	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
	    // Handle item selection
	    switch (item.getItemId()) {
	    case R.id.menu_item_settings:
	    	// show the settings screen
	        showSettings();
	        return true;
	    case R.id.menu_item_refresh:
			// re-initialise UI
			try {
				initControls();
			} catch (Exception e) {
				Log.d("Error: ", e.toString());
			}
	    	return true;
	    default:
	        return super.onOptionsItemSelected(item);
	    }
	}

}
