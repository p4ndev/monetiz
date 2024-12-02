import React from "react";

export default abstract class BaseLayout extends React.Component{
    
    protected readonly iconInactiveColor = '#AFAFAF';
    protected readonly iconActiveColor = '#B700E9';
    protected readonly iconSize = 34;

    protected readonly tabContainerStyle = { 
        backgroundColor : '#FFF'
    };

    protected readonly tabScreenOptions = {
        headerShown : false,
        tabBarStyle : { height: 80 },
        tabBarActiveTintColor : this.iconActiveColor,
        tabBarInactiveTintColor : this.iconInactiveColor
    };
}