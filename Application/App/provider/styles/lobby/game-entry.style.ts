import { StyleSheet } from "react-native";

export const GameEntryStyle = StyleSheet.create({
  stage: {
      borderBottomColor: 'rgba(0,0,0,0.2)',
      backgroundColor: '#f2f2f2',
      borderBottomWidth: 5,
      borderRadius: 15,
      
      flexDirection: 'row',
      alignItems: 'center',
      textAlign: 'center',
      marginBottom: 20
  },
  left: {
      width: '45%',
      height: 150,
      justifyContent: 'center',
      alignItems: 'center'
  },
  center: {
      width: '10%',
      height: 150,
      justifyContent: 'center',
      alignItems: 'center'
  },
  right: {
      width: '45%',
      height: 150,
      justifyContent: 'center',
      alignItems: 'center'
  },
  icon: {
      width: 80,
      height: 80,
  },
  playerName: {
      fontSize: 16,
      marginTop: 5
  },
  label: {
    width: 120,
    fontSize: 16,
    textAlign: 'center',
    opacity: 0.4
  },
  cross: {
    fontSize: 34,
    opacity: 0.3
  }
});