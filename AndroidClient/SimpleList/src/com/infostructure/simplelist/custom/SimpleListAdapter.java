package com.infostructure.simplelist.custom;

import java.util.List;

import com.infostructure.simplelist.R;
import com.infostructure.simplelist.model.SimpleList;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.LinearLayout;
import android.widget.TextView;

public class SimpleListAdapter extends ArrayAdapter<SimpleList> {

	int resource;
	String response;
	Context context;
	
	// initialize adapter
	public SimpleListAdapter(Context context, int resource, List<SimpleList> items) {
		super(context, resource, items);
		this.resource = resource;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		LinearLayout simpleListView;
		
		//Get the current alert object
		SimpleList simpleList = getItem(position);

		//Inflate the view
		if(convertView == null)
		{
			simpleListView = new LinearLayout(getContext());
			String inflater = Context.LAYOUT_INFLATER_SERVICE;
			LayoutInflater vi;
			vi = (LayoutInflater)getContext().getSystemService(inflater);
			vi.inflate(resource, simpleListView, true);
		}
		else
		{
			simpleListView = (LinearLayout)convertView;
		}
		
		//Get the text boxes from the listitem.xml file
		TextView textViewName = (TextView)simpleListView.findViewById(R.id.textViewName);
		TextView textViewDateAdded = (TextView)simpleListView.findViewById(R.id.textViewDateAdded);

		//Assign the appropriate data from our alert object above
		textViewName.setText(simpleList.getName());
		textViewDateAdded.setText(simpleList.getDateAdded().toString());

		return simpleListView;
	}
}
