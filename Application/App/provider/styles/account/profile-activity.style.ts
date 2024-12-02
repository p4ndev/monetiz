import { StyleSheet } from 'react-native';

export const ProfileActivityStyle = StyleSheet.create({
    stage: {
      marginBottom: 10,
      paddingVertical: 20,
      paddingHorizontal: 15
    },

    header: {
      flexDirection: 'row',
      height: 70
    },
  headerLeft: {
    flexBasis: '85%'
  },
  headerRight: {
    flexBasis: '15%',
    alignItems: 'flex-end',
    justifyContent: 'center'
  },

  headline: {
    fontSize: 20,
    marginBottom: 20
  },

  iconStage: {
    width: 65,
    height: 65,
    borderRadius: 65,
    alignItems: 'center',
    justifyContent: 'center',
    transform: 'scale(0.9)'
  },
  iconLabel: {
    fontSize: 15,
    color: '#FFF'
  },

  footer: {
    paddingTop: 15,
    flexDirection: 'row',
    justifyContent: 'space-between'
  },

  row: {
    flexDirection: 'row'
  },
  answer: {
    fontSize: 16,
    textTransform: 'uppercase'
  },
  label: {
    fontSize: 14
  }
});
