import { StyleSheet } from 'react-native';

export const AccountStyle = StyleSheet.create({
  stage: {
    paddingHorizontal: 10
  },
  form: {
    paddingHorizontal: 10
  },
  label: {
    fontSize: 16,
    color: 'white',
      marginBottom: 5
  },
  requirement: {
    color: 'white',
    fontStyle: 'italic',
    marginTop: 15
  },
  submitRow: {
    flexDirection: 'row',
    marginTop: 5
  },
  submitLeft: {
    flex: 2
  },
  submitRight: {
    flex: 1
  }
});