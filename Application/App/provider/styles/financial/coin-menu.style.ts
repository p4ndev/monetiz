import { StyleSheet } from "react-native";

export const CoinMenuItemStyle = StyleSheet.create({
  stage: {
    height: 120,
    width: 270,
    marginTop: -40,
    overflow: 'hidden'
  },
  label: {
    zIndex: 4,
    fontSize: 22,
    color: 'white',
    width: '100%',
    height: 50,
    paddingTop: 10,
    textAlign: 'center',
    position: 'absolute',
    marginTop: 58,
    marginLeft: 5
  },
  centerCoin: {
    zIndex: 3,
    width: 180,
    height: 180,
    marginLeft: 52,
    position: 'absolute',
    marginTop: 10
  },
  leftCoin: {
    zIndex: 1,
    width: 120,
    height: 120,
    marginLeft: 20,
    position: 'absolute',
    marginTop: 55
  },
  rightCoin: {
    zIndex: 2,
    width: 90,
    height: 90,
    marginLeft: 170,
    position: 'absolute',
    marginTop: 80
  }
});