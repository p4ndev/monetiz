import { StyleSheet } from 'react-native';

const boxWidth          = 360;
const boxHeight         = 180;
const boxHeadlineSize   = 35;
const boxContentSize    = 18;
const boxHeadlineColor  = '#B700E9';

export const FloatPanelStyle = StyleSheet.create({
    stage: {
        backgroundColor: 'rgba(0,0,0,0.5)'
    },
    box: {        
        padding: 25,
        borderRadius: 10,
        backgroundColor: 'white'
    },

    loaderBox: {
        width: boxWidth,
        minHeight: boxHeight,
        alignItems: 'center',
        justifyContent: 'center'        
    },
    loaderBoxName: {
        fontSize: boxHeadlineSize,
        color: boxHeadlineColor,
        marginBottom: 10
    },

    informationBox: {
        width: boxWidth,
        minHeight: boxHeight,
        alignItems: 'flex-start',
        justifyContent: 'flex-start'
    },
    informationBoxName: {
        fontSize: boxHeadlineSize,
        color: boxHeadlineColor,
        marginBottom: 10
    },
    informationBoxContent: {
        fontSize: boxContentSize
    },

    confirmationBox: {
        width: boxWidth,
        minHeight: boxHeight,
        alignItems: 'flex-start',
        justifyContent: 'flex-start'
    },
    confirmationBoxName: {
        fontSize: boxHeadlineSize,
        color: boxHeadlineColor,
        marginBottom: 10
    },
    confirmationBoxContent: {
        fontSize: boxContentSize,
        minHeight: 50
    },
    informationSubmit: {
        width: 100,
        marginTop: 30,
        alignSelf: 'flex-end'
    }
});