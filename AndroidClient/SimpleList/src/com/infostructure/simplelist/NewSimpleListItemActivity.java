package com.infostructure.simplelist;

import com.infostructure.simplelist.R;
import com.infostructure.simplelist.abstractions.BaseSimpleListActivity;
import com.infostructure.simplelist.abstractions.UserInterface;
import com.infostructure.simplelist.model.UserCredentials;
import com.infostructure.simplelist.utils.DataAccess;

import android.app.Activity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class NewSimpleListItemActivity extends Activity implements UserInterface {
	
	private EditText editTextListItemDescription = null;
	private Button buttonAddNewListItem = null;
	private DataAccess dataAccess = null;
	
	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.new_simple_list_item);
		
		// setup our data access manager
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
		
		// setup the controls
		buttonAddNewListItem = (Button)findViewById(R.id.buttonAddNewListItem);
		editTextListItemDescription = (EditText)findViewById(R.id.editTextListItemDescription);
		
		// new item button event
		buttonAddNewListItem.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				try {
					dataAccess.createSimpleListItem(BaseSimpleListActivity.getCurrentSimpleListId(), editTextListItemDescription.getText().toString());
				} catch (Exception e) {
					Log.d("Error: ", e.toString());
					return;
				}
			}
		});		
	}
}
