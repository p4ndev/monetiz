import { StyleSheet } from "react-native";

export const CoinStyle = StyleSheet.create({
  middleStage: {
    marginVertical: 5
  },
  sellStage: {
    marginTop: 15
  },
  stage: {
    paddingHorizontal: 10,
    flexDirection: 'row',
    width: '100%',
  },
  stageWrapper: {
    marginTop: 12
  },
  leftColumn: {
    justifyContent: 'center',
    alignItems: 'center',
    width: '35%'
  },
  centerColumn: {
    justifyContent: 'center',
    width: '31%'
  },
  rightColumn: {
    justifyContent: 'center',
    paddingTop: 20,
    width: '34%',
    height: 100
  },

  amount: {
    color: '#ffe200',
    fontSize: 30,
    marginBottom: -6
  },
  label: {
    color: '#FFF',
    fontSize: 16
  },

  firstIcon: {
    position: 'absolute',
    width: 95,
    height: 54,
    marginTop: 10,
    marginLeft: -5
  },
  firstWrapper:{
    width: 80,
    height: 80,
    borderRadius: 80,
    backgroundColor: 'rgba(0,0,0,0.2)'
  },

  secondIcon: {
    position: 'absolute',
    width: 100,
    height: 65,
    marginTop: 7,
    marginLeft: -12,
  },
  secondWrapper:{
    width: 80,
    height: 80,
    borderRadius: 80,
    backgroundColor: 'rgba(0,0,0,0.2)'
  },

  thirdIcon: {
    position: 'absolute',
    width: 90,
    height: 90,
    marginLeft: -10,
    marginTop: 0
  },
  thirdWrapper:{
    width: 85,
    height: 85,
    borderRadius: 85,
    backgroundColor: 'rgba(0,0,0,0.2)'
  },

  fourthIcon: {
    position: 'absolute',
    width: 115,
    height: 115,
    marginTop: -10,
    marginLeft: -10
  },
  fourthWrapper:{
    width: 95,
    height: 95,
    borderRadius: 90,
    backgroundColor: 'rgba(0,0,0,0.2)'
  }
});