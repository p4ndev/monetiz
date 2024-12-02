import { StyleSheet } from 'react-native';

const HowToPlayStyle = StyleSheet.create({
    stage: {
        flexDirection: 'column'
    },
    inquiryStage: {
        paddingHorizontal: 25,
        paddingTop: 10,
        paddingBottom: 30
    },
    inquiryTitle: {
        fontSize: 15
    },
    inquiryMessage: {
        fontSize: 15
    },
    inquiryEmail: {
        textDecorationLine: 'underline'
    }
});

const HowToPlayEntryStyle = StyleSheet.create({
    stage: {
        borderRadius: 10,
        marginBottom: 10,
        marginHorizontal: 10,
        paddingVertical: 15,
        paddingHorizontal: 10,
        backgroundColor: '#F7F7F7'
    },
    link: {
        fontSize: 18,
        marginBottom: 5,
        color: '#727272'
    },
    activeStage: {
        backgroundColor: '#FDF5FF'
    },
    activeLink: {
        color: '#8600FF'
    },
    activeContent: {
        color: '#B462FF'
    }
});

export { HowToPlayStyle, HowToPlayEntryStyle }