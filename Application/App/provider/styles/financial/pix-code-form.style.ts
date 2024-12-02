import { StyleSheet } from "react-native";

export const PixCodeFormStyle = StyleSheet.create({
  stage: {
    paddingHorizontal: 10,
    flexDirection: 'row',
    height: 110
  },
  stageClipboard: {
    paddingHorizontal: 10,
    flexDirection: 'row'
  },
  leftCell: {
    width: '80%'
  },
  rightCell: {
    paddingLeft: '1%',
    width: '20%'
  },
  keyFormat: {
    marginTop: 8,
    fontSize: 17
  },
  FormatBox: {
    backgroundColor: '#FFFFFF',
    color: '#B700E9',
    fontStyle: 'normal',
    marginHorizontal: 2,
    borderRadius: 5,
    paddingHorizontal: 6,
    paddingVertical: 4
  },
  helper: {
    fontStyle: 'italic',
    color: 'white',
    fontSize: 15
  }
});