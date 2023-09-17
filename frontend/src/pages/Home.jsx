import React, { Component } from 'react'
import { connect } from 'react-redux'
import PropTypes from 'prop-types'
import { fetchPosts } from '../Redux/Actions/TwitterActions'
import SenderMessage from '../components/Messages/SenderMessage'
import ReceivedMessage from '../components/Messages/ReceivedMessage'

class Home extends Component {
    componentDidMount() {
        this.props.fetchPosts();
    }
    render() {
        return (
            <div>
				<SenderMessage timestamp="12:46pm" status="Read" avatarUrl="https://example.com/example.png">This is me just saying hello world</SenderMessage>
                <ReceivedMessage username="Jeff" timestamp="12:46pm" status="Read" avatarUrl="https://example.com/example.png">I am replying with hello world again!!!</ReceivedMessage>
            </div>
        )
    }
}
Home.propTypes = {
    fetchPosts: PropTypes.func.isRequired
}

const mapStateToProps = state => ({
    twitter: state.twitter.items
});

export default connect(mapStateToProps, { fetchPosts })(Home)