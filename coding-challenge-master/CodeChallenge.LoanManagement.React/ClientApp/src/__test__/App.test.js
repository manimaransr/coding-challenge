import renderer from 'react-test-renderer';
import React from 'react';
import { shallow } from 'enzyme';
import App from '../App';

describe('App component', () => {

    it('matches the snapshot', () => {
        const tree = renderer.create(<App />).toJSON();
        expect(tree).toMatchSnapshot();
    });

    it('starts with a count of 0', () => {
        const wrapper = shallow(<App />);
        const text = wrapper.find('p').text();
        expect(text).toEqual('Count: 0');
    });
  

  
});
