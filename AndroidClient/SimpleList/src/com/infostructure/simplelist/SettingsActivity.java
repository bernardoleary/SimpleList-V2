package com.infostructure.simplelist;

import com.infostructure.simplelist.R;
import com.infostructure.simplelist.abstractions.UserInterface;
import com.infostructure.simplelist.model.UserCredentials;
import com.infostructure.simplelist.utils.DataAccess;

import android.app.Activity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class SettingsActivity extends Activity implements UserInterface {
	
	private EditText editTextUserName = null;
	private EditText editTextPassword = null;
	private Button buttonSave = null;
	private DataAccess dataAccess = null;
	
	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.settings);
		
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
		buttonSave = (Button)findViewById(R.id.buttonSave);
		editTextUserName = (EditText)findViewById(R.id.editTextUserName);
		editTextPassword = (EditText)findViewById(R.id.editTextPassword);
		
		// save button event
		buttonSave.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				UserCredentials userCrednetials = new UserCredentials();
				userCrednetials.setUserName(editTextUserName.getText().toString());
				userCrednetials.setPassword(editTextPassword.getText().toString());
				try {
					dataAccess.setUserCredentials(userCrednetials);
				} catch (Exception e) {
					Log.d("Error: ", e.toString());
					return;
				}
			}
		});
		
		// setup the textbox contents
		UserCredentials userCredentials = dataAccess.getUserCredentials();			
		editTextUserName.setText(userCredentials.getUserName());			
		editTextPassword.setText(userCredentials.getPassword());
	}
}
