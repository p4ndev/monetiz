import { StyleSheet } from "react-native";

export const TenantEntryStyle = StyleSheet.create({
  stage: {
      borderBottomColor: 'rgba(0,0,0,0.2)',
      justifyContent: 'space-between',
      backgroundColor: '#CCC',
      borderBottomWidth: 7,
      flexDirection: 'row',
      alignItems: 'center',
      marginBottom: 15,
      borderRadius: 20,
      width: '100%'
  },
  label: {
      fontSize: 22,
      paddingLeft: 40,
      textTransform: 'uppercase'
  },
  icon: {
      width: 140,
      height: 140,
      marginRight: 20
  }
});