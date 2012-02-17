package com.infostructure.simplelist.custom;

import java.util.List;

import com.infostructure.simplelist.R;
import com.infostructure.simplelist.model.SimpleList;
import com.infostructure.simplelist.model.SimpleListItem;
import com.infostructure.simplelist.utils.DataAccess;

import android.app.ListActivity;
import android.content.Context;
import android.content.pm.ActivityInfo;
import android.content.res.Configuration;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.CompoundButton.OnCheckedChangeListener;
import android.widget.LinearLayout;
import android.widget.RelativeLayout;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.ToggleButton;

public class SimpleListItemAdapter extends ArrayAdapter<SimpleListItem> {

	private int resource;
	private String response;
	private Context context;
	private LinearLayout simpleListItemView;
	private DataAccess dataAccess = null;
	private List<SimpleListItem> items = null;
	
	// initialize adapter
	public SimpleListItemAdapter(Context context, int resource, List<SimpleListItem> items) {
		super(context, resource, items);
		this.resource = resource;
		this.dataAccess = new DataAccess(context);
		this.items = items;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		
		//Get the current alert object
		SimpleListItem simpleListItem = getItem(position);

		//Inflate the view
		if(convertView == null)
		{
			simpleListItemView = new LinearLayout(getContext());
			String inflater = Context.LAYOUT_INFLATER_SERVICE;
			LayoutInflater vi;
			vi = (LayoutInflater)getContext().getSystemService(inflater);
			vi.inflate(resource, simpleListItemView, true);
		}
		else
		{
			simpleListItemView = (LinearLayout)convertView;
		}
		
		//Get the text boxes from the listitem.xml file
		TextView textViewDescription = (TextView)simpleListItemView.findViewById(R.id.textViewDescription);
		textViewDescription.setText(simpleListItem.getDescription());
		
		//Capture the button that has been clicked
		Button buttonHide = (Button)simpleListItemView.findViewById(R.id.buttonHide);
		buttonHide.setOnClickListener(new OnClickListener() {
	        @Override
	        public void onClick(View v) {
	        	
	        	//Update the View so as we don't show that item anymore
	        	//Need to go two levels up because of the layout structure
	        	RelativeLayout relativeLayout = (RelativeLayout)v.getParent().getParent();	        		        	
	        	ViewGroup viewGroup = (ViewGroup)relativeLayout.getParent();
	        	viewGroup.removeView(relativeLayout);
	        	viewGroup.invalidate();	        	
	        }
	    });
		if (!simpleListItem.getDone())
			buttonHide.setVisibility(View.INVISIBLE);
		
		//Capture the button that has been clicked
		Button buttonDelete = (Button)simpleListItemView.findViewById(R.id.buttonDelete);
		buttonDelete.setOnClickListener(new OnClickListener() {
	        @Override
	        public void onClick(View v) {
	        	
	        	//Get the component we're working with
	        	RelativeLayout relativeLayout = (RelativeLayout)v.getParent().getParent();	 
	        	
	        	try {
	        		
		        	//Update the database
	        		TextView textViewDescription = (TextView)relativeLayout.findViewById(R.id.textViewDescription);
	        		SimpleListItem item = getSimpleListItem(textViewDescription);
	        		dataAccess.deleteSimpleListItem(item.getSimpleListID(), item.getId());
					
					//Redraw       		        	
		        	ViewGroup viewGroup = (ViewGroup)relativeLayout.getParent();
		        	viewGroup.invalidate();	  
	        	
				} catch (Exception e) {
					Log.d("Error: ", e.toString());
				}
	        }
	    });
		
		//Capture the button that has been toggled
		CheckBox checkboxDone = (CheckBox)simpleListItemView.findViewById(R.id.checkboxDone);
		checkboxDone.setChecked(simpleListItem.getDone());		
		checkboxDone.setOnClickListener(new OnClickListener() {
	        @Override
	        public void onClick(View v) {
	        	
	        	//Get the component we're working with
	        	RelativeLayout relativeLayout = (RelativeLayout)v.getParent().getParent();	 
	        	
	        	try {
	        		
		        	//Update the database
	        		TextView textViewDescription = (TextView)relativeLayout.findViewById(R.id.textViewDescription);
	        		SimpleListItem item = getSimpleListItem(textViewDescription);
	        		dataAccess.toggleSimpleListItemDone(item.getSimpleListID(), item.getId());
					
					//Toggle Hide button's visibility
					CheckBox checkboxDone = (CheckBox)relativeLayout.findViewById(R.id.checkboxDone);					
					Button buttonHide = (Button)relativeLayout.findViewById(R.id.buttonHide);
					buttonHide.setVisibility(checkboxDone.isChecked() ? View.VISIBLE : View.INVISIBLE);
					
					//Redraw       		        	
		        	ViewGroup viewGroup = (ViewGroup)relativeLayout.getParent();
		        	viewGroup.invalidate();	   
		        	
				} catch (Exception e) {
					Log.d("Error: ", e.toString());
				}
	        }
	    });
		
		return simpleListItemView;
	}
	
	private SimpleListItem getSimpleListItem(TextView textView) {    		        	
    	SimpleListItem item = null;
    	for (int i = 0; item == null; i++) 
    		item = items.get(i).getDescription() == textView.getText() ? 
    			items.get(i) :
    			null;
		return item;
	}
}
