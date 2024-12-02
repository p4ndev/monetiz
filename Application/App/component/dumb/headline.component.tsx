import { Text, View } from 'react-native';

import i18n from '../../provider/locales/translation';
import { HelperStyle } from '../../provider/styles';

import { HeadlinePropsInterface } from '../../shared/interfaces';

const Headline = {
  Colorful: (props : HeadlinePropsInterface) => (
    <View style={HelperStyle.baseHeadline} id={props.id}>
      <Text id='headline' style={[HelperStyle.headline, HelperStyle.bold]}>
        { props.i18n ? i18n.t(props.i18n) : props.content }
      </Text>
    </View>
  ),
  Light: (props : HeadlinePropsInterface) => (
    <View style={HelperStyle.baseHeadline} id={props.id}>
      <Text style={[HelperStyle.headline, HelperStyle.headlineLight, HelperStyle.bold]}>
      { props.i18n ? i18n.t(props.i18n) : props.content }
      </Text>
    </View>
  ),
  Dark: (props : HeadlinePropsInterface) => (
    <View style={HelperStyle.baseHeadline} id={props.id}>
      <Text style={[HelperStyle.headline, HelperStyle.headlineDark, HelperStyle.bold]}>
      { props.i18n ? i18n.t(props.i18n) : props.content }
      </Text>
    </View>
  )
};

export default Headline;