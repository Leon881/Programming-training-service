import React from 'react';
import PropTypes from 'prop-types';
import {BrowserRouter as Router, Switch, Route, Link} from 'react-router-dom'
import ReturnButton from "../../containers/ReturnButton";

export default function Articles ({text}) {
    return (
        <div>
        <ReturnButton/>
      <p>Статьи</p>\
      <div dangerouslySetInnerHTML={{__html:text}}></div>
      </div>
    )
}

Articles.propTypes = {
}
