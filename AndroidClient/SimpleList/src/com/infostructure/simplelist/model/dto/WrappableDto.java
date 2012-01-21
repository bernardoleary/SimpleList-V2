package com.infostructure.simplelist.model.dto;

public abstract class WrappableDto {

	protected Boolean wrapped = false;
	protected String wrapName = "";
	
	public Boolean getIsWrapped() {
		return wrapped;
	}
	
	public void setIsWrapped(Boolean wrapped) {
		this.wrapped = wrapped;
	}
}
